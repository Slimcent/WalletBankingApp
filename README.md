# Wallet Banking API

Wallet Banking API is a digital wallet and banking REST API built with .NET 8 and ASP.NET Core.

The application provides backend services for customer and staff management, authentication, wallet transactions, deposits, withdrawals, transfers, bill payments, airtime purchases, data purchases and transaction history.

The solution follows a multi-project architecture that separates API concerns, business logic, persistence, domain entities, logging and testing.

## Features

### Authentication and Authorization

* User authentication
* JWT-based authentication
* Role management
* Claims management
* Protected API endpoints
* Swagger JWT authorization support

### Customer Management

* Customer management
* Customer account operations
* Customer profile functionality
* Profile picture support
* User and account-related services

### Staff Management

* Staff management
* Role management
* Claims management
* Administrative API operations

### Wallet Transactions

The API supports:

* Deposit funds
* Withdraw funds
* Transfer funds between accounts
* Retrieve transaction history
* Process wallet transactions through a dedicated service layer

### Bill and Utility Payments

The wallet can also process:

* Bill payments
* Airtime purchases
* Mobile data purchases

## Technology Stack

* C#
* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* JWT Bearer Authentication
* Swagger / OpenAPI
* SQL Server support
* PostgreSQL support
* NLog
* Serilog
* Docker
* Docker Compose
* GitHub Actions

## Architecture

The solution is separated into several projects:

```
WalletBankingApp
│
├── WalletApi
│   ├── Controllers
│   ├── Authentication
│   ├── ActionFilters
│   ├── Middlewares
│   ├── ModelBinder
│   ├── Migrations
│   ├── Data
│   └── API configuration
│
├── Wallet.Services
│   ├── Services
│   ├── Interfaces
│   ├── Helpers
│   ├── Exceptions
│   └── Enums
│
├── Wallet.Data
│   ├── Repository
│   ├── UnitOfWork
│   ├── Interfaces
│   ├── Extensions
│   └── Seeders
│
├── Wallet.Entities
│   ├── Domain Models
│   ├── DTOs
│   ├── Interfaces
│   ├── Enums
│   ├── Helpers
│   └── Mappers
│
├── Wallet.Logger
│   └── Logging infrastructure
│
├── Wallet.IntegrationTest
│   └── API integration tests
│
├── Wallet.IntegrationTesting
│   └── Integration-testing infrastructure
│
└── Wallet.UnitTest
    └── Unit-testing project
```

This separation keeps API endpoints, business rules, persistence, domain models, logging and testing concerns isolated from one another.

## API Structure

The API contains controllers for areas including:

* Authentication
* Customers
* Staff
* Transactions
* Bills
* Roles
* Claims
* Lookup/select operations

The transaction API provides endpoints for common digital wallet operations.

```
POST /api/customer/deposit
POST /api/customer/withdraw
POST /api/customer/transfer
POST /api/customer/pay-bill
POST /api/customer/buy-airTime
POST /api/customer/buy-data
GET  /api/customer
```

## Transaction Processing

### Deposit

A customer can fund a wallet or account using the deposit operation.

### Withdrawal

The withdrawal workflow processes deductions from the customer's available account balance.

### Transfer

The transfer operation allows funds to be moved between accounts through the transaction service.

### Bill Payment

Customers can make bill payments from their wallet.

### Airtime Purchase

The API supports airtime purchases through the wallet transaction system.

### Data Purchase

Customers can also purchase mobile data using funds available in their wallet.

## Service Layer

Business logic is separated into dedicated services, including:

```
AccountService
AuthenticationService
BackgroundTaskService
BillService
CustomerService
ProfilePictureService
RoleService
SelectService
StaffService
TransactionService
UserService
```

This structure keeps controllers focused on HTTP concerns while business operations are handled within the service layer.

## Repository and Unit of Work

Database access is separated into the `Wallet.Data` project.

The persistence layer implements:

* Repository abstraction
* Unit of Work pattern
* Data-access interfaces
* Database seeders
* Database configuration extensions

The general request flow follows:

```
Client
  ↓
ASP.NET Core Controller
  ↓
Service Layer
  ↓
Repository / Unit of Work
  ↓
Entity Framework Core
  ↓
Database
```

## Authentication

JWT Bearer authentication is configured for the API.

Swagger also includes Bearer-token support, allowing authenticated endpoints to be tested directly through Swagger UI.

A typical request uses:

```
Authorization: Bearer <token>
```

## API Documentation

Swagger/OpenAPI is configured for API exploration and testing.

When the application is running, Swagger provides:

* API endpoint documentation
* Request and response models
* Interactive endpoint testing
* JWT Bearer authentication support

## Error Handling and Validation

The API includes dedicated infrastructure for application concerns such as:

* Model-state validation
* Media-type validation
* Exception-handling middleware
* Custom action filters
* Model binding
* JSON serialization configuration

These components help keep validation and error-handling concerns separate from core business logic.

## Logging

Logging is separated into the `Wallet.Logger` project.

The API also includes configuration for:

* NLog
* Serilog
* Console logging
* Application-level logging

## Entity Framework Core

Entity Framework Core is used for persistence.

The API project includes database providers for both:

* Microsoft SQL Server
* PostgreSQL

Database migrations are maintained inside the API project.

## Docker

The application includes Docker support.

Relevant files include:

```
WalletApi/Dockerfile
docker-compose.yml
docker-compose.override.yml
docker-compose.dcproj
```

Build the API image manually with:

```
docker build -t walletapi -f WalletApi/Dockerfile .
```

Docker Compose can also be used to start the configured application environment.

```
docker compose up --build
```

## CI/CD

The repository includes a GitHub Actions workflow for continuous integration and deployment.

The pipeline performs:

```
Push / Pull Request
        ↓
Restore .NET dependencies
        ↓
Build solution
        ↓
Build Docker image
        ↓
Push image to Docker Hub
        ↓
Deploy application
```

The workflow targets .NET 8, builds the solution, creates the Wallet API Docker image, pushes the image to Docker Hub and contains a deployment stage for Render.

## Testing

The solution contains projects dedicated to both unit and integration testing:

```
Wallet.UnitTest
Wallet.IntegrationTest
Wallet.IntegrationTesting
```

Run tests across the solution with:

```
dotnet test
```

## Getting Started

### Prerequisites

Install:

* .NET 8 SDK
* Docker Desktop, if using containers
* A supported relational database

### Clone the Repository

```
git clone https://github.com/Slimcent/WalletBankingApp.git
cd WalletBankingApp
```

### Restore Dependencies

```
dotnet restore WalletBankingApp.sln
```

### Build

```
dotnet build WalletBankingApp.sln
```

### Run the API

```bash
dotnet run --project WalletApi
```

Alternatively, run with Docker:

```bash
docker compose up --build
```

## Project Highlights

This project demonstrates practical backend engineering concepts including:

* REST API development
* ASP.NET Core
* .NET 8
* Layered application architecture
* Dependency injection
* Repository pattern
* Unit of Work pattern
* Entity Framework Core
* JWT authentication
* Claims and role management
* Middleware
* Action filters
* Request validation
* Exception handling
* Swagger/OpenAPI
* Financial transaction processing
* Bill payment workflows
* Docker containerization
* CI/CD with GitHub Actions
* Docker Hub integration
* Automated deployment
* Unit and integration testing
* Structured logging

## Author

**Obinna Vincent Achara**

GitHub: [@Slimcent](https://github.com/Slimcent)
