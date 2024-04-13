# Technology Blog Project

This project is a technology blog application developed using .NET Core MVC. The project is being developed on .NET 8.0 and follows a layered architecture, aiming to produce high-quality code adhering to clean code principles and SOLID principles.

## Features

- **Entity Framework Core**: Entity Framework Core is used for database operations.
- **Microsoft SQL Server**: Microsoft SQL Server is chosen as the database.
- **Microsoft Identity**: Microsoft Identity is used for authentication.
- **Razor View**: Razor Views, Layouts are used for web pages.
- **Service Logging**: Serilog library is used to log actions in services (text sink).

## Project Structure

The project consists of two main parts:

1. **Visitor Area**: This is the part that visitors to the site will see. Here, access to technology content is provided, and features that visitors can benefit from are available. Visitors to our page can stay informed about new technology information, read articles in full, and freely utilize features such as search, pagination, and searching by categories. Additionally, they can take advantage of functionalities like login and registration.

2. **Admin Area**: This is the part where authorized users (Admin, SuperAdmin, etc.) can manage the site's content. This area constitutes the main functionality of the project and most of the work happens here. Once logged into our page, administrators can perform detailed operations on new articles and their categories. These changes will be instantly visible to visitors on the site.

## Frontend

In the frontend part, ready-made templates are used for both sections. Different themes are chosen for the visitor area and the admin area.

You can find the templates: 

1. For **Visitor Area**: [Blog-stand](https://www.free-css.com/free-css-templates/page270/stand-blog)
  
2. For **Admin Area**: [Sneat](https://themeselection.com/item/sneat-dashboard-free-bootstrap/)

## How to Use

1. Clone the project.
2. Open the project in Visual Studio or your preferred IDE.
3. Set up the database connection settings.
4. Compile and run the project.
5. Visit customized `localhost:port` in your browser to view the application.

## Contributions

If you would like to contribute, please fork the project and submit a pull request. We will do our best to review and merge it.
