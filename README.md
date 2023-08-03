
<a name="readme-top"></a>

# LibraryMVC-V2

This project is a continuation of the previous "Library MVC-V1" project, you can find it [here](https://github.com/EmreToklu00/LibraryMVC-V1).

While learning .NET Core MVC, I prepared this project. I applied all the features I learned to the best of my ability. I wanted to keep the appearance of the site simple and straightforward, and I spent more time on backend processes.

Since I'm new to .NET Core MVC, any kind of feedback is important to me. It will help me identify areas where I can improve and address any shortcomings.

Once I prepare other versions, I will share them in a separate repository.

## Features
- I worked with .NET Core 3.1 version.
- I used SQLite as the database.
- I tried to keep the view part as simple as possible and used Bootstrap.
- I developed the project using the Modular Architecture (Entity, Data, Business, WebUI).

## Data Module:

- Manages database operations and handles communication with the database.
- Utilizes ORM (Object-Relational Mapping) tools like Entity Framework or Dapper to establish a connection with the database.
- Provides necessary CRUD (Create, Read, Update, Delete) operations for database access.

## Entity Module:

- Defines object models and relationships to be used in the database.
- Typically, uses the Entity Framework Code-First approach to convert database tables into C# objects.

## Business Module:

- Manages business rules and logic in the project.
- Processes data received from the Data module, performs necessary calculations, and manages business processes.
- Utilizes functionalities provided by the Data and Entity modules to build the project's business logic.

## WebUI Module:

- Provides a web interface for users to access the project.
- Creates the user interface using Razor Pages or the MVC framework.
- Interacts with users by displaying data received from the business logic module.

## Screenshots

![](https://github.com/EmreToklu00/LibraryMVC-V2/blob/main/github/adminbooks.png)
![](https://github.com/EmreToklu00/LibraryMVC-V2/blob/main/github/admincategories.png)
![](https://github.com/EmreToklu00/LibraryMVC-V2/blob/main/github/home.png)
![](https://github.com/EmreToklu00/LibraryMVC-V2/blob/main/github/library.png)

<p align="right"><-<a href="#readme-top">back to top</a>-></p>
