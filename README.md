# Restaurant API

A RESTful API built with **ASP.NET Core 8**, following **Onion Architecture** principles for scalability and maintainability. This API supports **role-based access control (RBAC)** and provides management features for ingredients, dishes, tables, and orders. It uses **Entity Framework Core** (Code-First) and **JWT** for secure authentication.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [How to Contribute](#how-to-contribute)


## Features
- **Authentication and Authorization**:
   - Secure **JWT-based authentication** with **role-based access control**:
     - **Administrator**: Manages ingredients, dishes, tables, and admin tasks.
     - **Waiter**: Manages orders.
     - **Super Administrator**: Combines both roles.
   - Unauthorized access returns standard HTTP status codes: `401 Unauthorized` or `403 Forbidden`.

- **Identity Management**:
   - Integrated with **Identity** for user authentication and account management.
   - Default roles automatically created during setup: **Administrator**, **Waiter**, **Super Administrator**.
   - Secure account creation and login.

- **Management Features**:
   - Full **CRUD operations** for managing **ingredients, dishes, tables, and orders**.
   - Order status management and linked data handling.

- **Architecture & Tools**:
   - **Onion Architecture**: Clean separation of concerns for better scalability.
   - **Entity Framework Core**: Code-First approach for database management.


## Technologies Used
- **Backend**: 
   - ASP.NET Core 8 Web API
   - Entity Framework Core
   - AutoMapper
   - Identity
   - JWT Authentication
- **Database**: SQL Server


## Getting Started

### Prerequisites
Ensure you have the following installed:
- **Visual Studio** with **.NET SDK 8** or later.
- **SQL Server**.

### Installation Steps
1. Clone the repository or download the project.
2. Navigate to the project directory:
   ```bash
   cd restaurant-web-api
   ```
4. Update the database connection string in `appsettings.json` to match your SQL Server setup and update the jwtSettings:
  ```json
  {
    "UseInMemoryDatabase": false,
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SQL_INSTANCE;Database=RestaurantWebApi;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=True",
      "IdentityConnection": "Server=YOUR_SQL_INSTANCE;Database=RestaurantWebApi;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=True"
    },
    "JWTSettings": {
      "Key": "YOUR_SECURE_JWT_SECRET_KEY",
      "Issuer": "CodeIdentity",
      "Audience": "RestaurantApiUser",
      "DurationInMinutes": 60
    }
  }
  ```
5. Install dependencies:
  ```bash
  dotnet restore
  ```
6. Open the Package Manager Console in Visual Studio and run `Update-Database` to apply migrations:
  ```bash
  dotnet ef database update --context ApplicationDbContext
  dotnet ef database update --context IdentityContext
  ```
7. Run the project with:
   ```bash
   dotnet run
   ```
Access it in your browser at http://localhost:5000 or https://localhost:5001.

## How to Contribute
1. Fork the repository.
2. Create a new branch (git checkout -b feature/YourFeature).
3. Commit your changes (git commit -m 'Add some feature').
4. Push to the branch (git push origin feature/YourFeature).
5. Open a pull request.
