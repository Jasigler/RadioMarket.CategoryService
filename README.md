
  <h3 align="center">RadioMarket Item Service API</h3>

  <p align="center">
    Category microservice for my 'Radiomarket' e-commerce project
</p>



## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Installation](#installation)
* [Usage](#usage)
* [Roadmap](#roadmap)
* [Contact](#contact)



## About The Project

This is the category microservice for my larger 'Radiomarket' project. This service performs basic CRUD operations for 'auction item' categories. This was separated from the items microservice in order to isolate it from the client as  deactivating a category will require the execution of a DB trigger to migrate all associated items to a new category.

A category consists of the following: 
``` c#
  int category_id,
  string name, 
  int? parent_id,
  bool is_active
```

A category is either a parent or a child/sub-category as denoted by the value of it's `parent_id` field. A `null` value is set for all parent categories, and it's `category_id` will be set as the `parent_id` of any sub-categories.

The `is_active` boolean is used as a filter when returning categories. In order to preserve data integrity for future reporting/auditing, etc, categories can simply be deactivated to preserve the item-category relationship.

There are two triggers that execute audit functions when a category is updated, created, or deactivaated. These functions write to an audit table that include the time, action, and user. 

### Built With

* ASP .NET Core 3.1
* Entity Framework Core
* Npgsql (EF Core extension)
* Postgres 12


<!-- GETTING STARTED -->
## Getting Started

In order to proceed, you need to deploy the [Item Microservice](https://github.com/Jasigler/RadioMarket.ItemService) first. 


### Installation

1. Run The DB migration scripts
```sh
cd ./Database
```
2. Clone the repo
```sh
git clone git@github.com:Jasigler/RadioMarket.ItemService.git
```
3. Build the solution
```sh
cd RadioMarket.CategoryService\Radiomarket.CategoryService && dotnet build
```
4. Run the solution
```sh
dotnet run
```



## Usage

Examples of requests and their responses are shown in Postman. Note that the `CategoryPath` variable is set to: 'https://localhost:1760'.

** Sample data was generated with [Datanamic](https://www.datanamic.com/). These generated items might not reflect the intended business domain. 

##### Get all active categories:
![Get all active categories](https://github.com/Jasigler/RadioMarket.CategoryService/blob/master/images/get_categories.PNG)
##### Create a new Category:
![Create new](https://github.com/Jasigler/RadioMarket.CategoryService/blob/master/images/add_category.PNG)


## Roadmap

This is an ongoing project.
See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a list of proposed features (and known issues).



<!-- CONTACT -->
## Contact

[@that_sigler](https://twitter.com/that_sigler) - jason.sigler@outlook.com

Project Link: [https://github.com/jasigler/repo_name](https://github.com/your_username/RadioMarket.CategoryService)


