# Simple User Management API

A simple ASP.NET Core Web API for managing users with CRUD operations, middleware-based authentication/logging/error handling, and integration tests.

## Features

- Create, read, update, and delete users
- Input validation using data annotations
- Authentication middleware with bearer token support
- Error handling middleware
- Logging middleware
- Automated API tests with xUnit

## Project Structure

- `UserManagementAPI/` - Main API project
- `UserManagementAPI/Controllers/` - API controllers
- `UserManagementAPI/Middleware/` - Authentication, logging, and error middleware
- `UserManagementAPI/Models/` - Data models
- `UserManagementAPI.Tests/` - Integration tests

## Prerequisites

- .NET 9 SDK
- Visual Studio / VS Code with C# support

## Run the API

From the project root:

```bash
dotnet run --project UserManagementAPI
```

The API will be available at:

- `https://localhost:5001/api/users` (or the port shown in the terminal)

## Run Tests

```bash
dotnet test UserManagementAPI.Tests/UserManagementAPI.Tests.csproj
```

## Authentication

Some requests require a bearer token. Use the following header:

```http
Authorization: Bearer techhive-secret-token
```

## Notes

The project uses in-memory storage for users during runtime, so data is not persisted between application restarts.
