using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Category
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }

        [Required]
        [MaxLength(20)]
        public string name { get; set; }

        public int? parent_id { get; set; }

        [Required]
        public bool is_active { get; set; }

    }
}
