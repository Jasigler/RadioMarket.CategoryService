using AutoMapper;
using DataLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Models.Interfaces;
using Services;

namespace RadioMarket.CategoryService
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ItemContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ItemConnection"));
            });
            services.AddAutoMapper(typeof(Startup));
            services.TryAddScoped<ICategoryRepository, CategoryRepository>();
            services.AddHealthChecks()
                .AddCheck("Default", () =>
                HealthCheckResult.Healthy("Healthy"), tags: new[] { "default" });
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                   builder =>
                   builder.WithOrigins("localhost").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
