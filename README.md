# Company Management System

A WPF-based Company Management System that allows users to manage products, employees, and customers. The project uses MySQL as the database and Entity Framework Core for data access.

## Features

- **Manage Products:** View, add, update, and delete products.
- **Manage Employees:** View, add, update, and delete employees.
- **Manage Customers:** View, add, update, and delete customers.
- **Display Images:** Load and display images associated with products, employees, and customers.

## Project Structure

- **WPF_Company_Management_System**
  - The main project that handles the UI and interactions.
- **DataAccess**
  - Contains the Entity Framework models, interfaces, and `AppDBContext` for database interactions.

## Technologies Used

- **WPF (Windows Presentation Foundation):** Used for building the desktop UI.
- **Entity Framework Core:** Used as the ORM for database interactions.
- **MySQL:** The database used for storing data related to products, employees, and customers.
- **C#:** The primary programming language.
- **XAML:** For designing the WPF UI.

## Database Structure

The application uses a MySQL database with three main entities:

1. **Product**
   - `Id`: int
   - `Name`: string
   - `Description`: string
   - `Category`: string
   - `Count`: int
   - `PicAddress`: string
   - `Price`: double

2. **Employee**
   - `Id`: int
   - `FirstName`: string
   - `LastName`: string
   - `Age`: int
   - `PhoneNumber`: decimal
   - `Email`: string
   - `Address`: string
   - `Department`: enum
   - `Salary`: double
   - `PicAddress`: string

3. **Customer**
   - `Id`: int
   - `FirstName`: string
   - `LastName`: string
   - `Age`: int
   - `PhoneNumber`: decimal
   - `Email`: string
   - `Address`: string
   - `BuyCount`: int
   - `PicAddress`: string

## Setup Instructions

### Prerequisites

- .NET 8 SDK
- MySQL Server (version 8.0 or higher)
- Visual Studio (recommended for development)

### Running the Project

#### 1. Set up the MySQL database:

- Create a new MySQL database called `management_system`.
- Update the connection string in `AppDBContext.cs` if necessary.

#### 2. Migrate the database:

- Open a terminal in the project directory.
- Run the following commands to apply the migrations:

    ```bash
    dotnet ef database update
    ```

#### 3. Run the WPF Application:

- Open the project in Visual Studio.
- Build and run the solution.

### Entity Framework Core Commands

#### Add Migration:
```bash
dotnet ef migrations add <MigrationName>
```

## Update Database

To update the database, run the following command in your terminal:

```bash
dotnet ef database update
```

## Contributing

If you would like to contribute to the project, feel free to create a pull request or open an issue.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
