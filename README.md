# Brew Coffee Task overview
The coffee shop repo has four projects: CoffeeShop.Api, CoffeeShop.Models, CoffeeShop.Web, and CoffeeShop.Test.\
The backend is CoffeeShop.Api(ASP.NET Core Web API), and frontend is CoffeeShop.Web (Blazor WebAssembly).

The main master branch is for the basic task 1, 2, 3. and the CheckWeather branch is for the extra credit. So, the CheckWeather branch has all the master features.\
The following description is based on the CheckWeather branch. We set up multiple startup projects with the sequence Api -> Web

## CoffeeShop.Api
This project is an ASP.NET Core Web API using .NET 7 Framework which references CoffeeShop.Models project and used the following packages:

### Packages:
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* Newtonsoft.Json
* Swashbuckle.AspNetCore

This project is using EntityFrameworkCore this ORM for data operation, Newtonsoft.Json is for converting JSON data to object, Swashbuckle.AspNetCore is for api test UI.

### Folder structure
We used a repository design pattern with the following structure:
* Controllers: coffee, order, and weather API controllers
* Data: Datacontext sql server setup and configuration
* Repository: CoffeeReopository, OrderRepository, and with relevant contracts for data access through designed methods

### Run
This project can be launched as a single startup project. All the Apis can be tested through swagger.
In the visual studio, click start to run.

## CoffeeShop.Models
This project is a Class Library using .NET 7 Framework targets .NET or .NET Standard.
There are three models: Coffee, Order, and Weather. This project cannot be launched as a single startup project as it is a library.

## CoffeeShop.Web
This project is a Blazor WebAssembly App using .NET 7 Framework for a web application that references CoffeeShop.Api and CoffeeShop.Models these two projects.

### Packages:
* BrowserInterop

This third-party package is a library wrapping Blazor JSInterop call for browser API. I used this package for getting user location(latitude, and longitude) for open weather API

### Folder structure
We used a service design pattern with the following structure:
* Pages: Razor component
* Services: CoffeeService, WeatherService, and relevant contracts for calling relevant web API and getting a response for relevant pages/components.

### Run
This project needs the CoffeeShop.Api project run first, so I set up multiple startup projects.

## CoffeeShop.Test
This is a xUnit test projects using packages FakeItEasy for unit test

