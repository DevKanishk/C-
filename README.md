# OnlineStore — ASP.NET Core E-Commerce Application

A full-stack e-commerce application built with **ASP.NET Core MVC**, **Entity Framework Core**, **ASP.NET Core Identity**, and a layered architecture.

The project demonstrates practical implementation of catalog browsing, product filtering, shopping basket management, authentication, checkout, order history, repository abstractions, and domain-driven application structure.

---

## Overview

OnlineStore is an e-commerce web application designed to demonstrate backend architecture and full-stack development using the ASP.NET Core ecosystem.

The application allows users to:

* Browse products
* Filter products by brand and type
* Add products to a shopping basket
* View basket totals
* Authenticate using ASP.NET Core Identity
* Checkout authenticated orders
* View previous orders
* Navigate through paginated catalog results

The frontend was also redesigned from the original sample styling into a modern responsive **OnlineStore** interface.

---

## Tech Stack

### Backend

* C#
* ASP.NET Core MVC
* Entity Framework Core
* ASP.NET Core Identity
* LINQ
* Dependency Injection
* Repository Pattern
* Specification Pattern
* Async/Await

### Frontend

* Razor Views
* HTML5
* CSS3
* Bootstrap
* JavaScript

### Testing

* xUnit

### Development Tools

* Visual Studio
* .NET CLI
* Git
* GitHub

---

## Architecture

The solution follows a layered architecture separating domain logic, infrastructure concerns, web presentation, and tests.

```text
OnlineStore
│
├── OnlineStore.ApplicationCore
│   ├── Entities
│   ├── Interfaces
│   ├── Services
│   └── Specifications
│
├── OnlineStore.Infrastructure
│   ├── Data
│   ├── Repositories
│   ├── Identity
│   └── Persistence
│
├── OnlineStore.Web
│   ├── Controllers
│   ├── Services
│   ├── ViewModels
│   ├── Views
│   └── wwwroot
│
└── OnlineStore.ApplicationCore.Tests
    └── Domain and application tests
```

### Request Flow

```text
Browser
   │
   ▼
ASP.NET Core MVC Controller
   │
   ▼
Application Service
   │
   ▼
Repository / Specification
   │
   ▼
Entity Framework Core
   │
   ▼
Database
```

This separation keeps business rules isolated from the web and persistence layers.

---

## Main Features

### Product Catalog

Users can browse available products through a responsive catalog interface.

Features include:

* Product cards
* Product images
* Pricing
* Brand filtering
* Product-type filtering
* Pagination
* Product count
* Add-to-basket functionality

The catalog uses the **Specification Pattern** to encapsulate filtering and query logic.

---

### Shopping Basket

Users can add products to their basket and review selected items before checkout.

The basket displays:

* Product image
* Product name
* Unit price
* Quantity
* Item total
* Basket subtotal
* Overall order total

Basket persistence is separated through a dedicated `BasketDbContext` and repository.

```text
BasketService
     │
     ▼
IAsyncRepository<Basket>
     │
     ▼
BasketRepository
     │
     ▼
BasketDbContext
```

---

### Authentication

Authentication is implemented using **ASP.NET Core Identity**.

The application supports:

* User registration
* Login
* Logout
* Authenticated checkout
* User-specific order history

Identity persistence is handled using a dedicated `AppIdentityDbContext`.

---

### Order Management

Authenticated users can proceed through checkout and create orders.

The order architecture includes:

```text
Order
│
├── Shipping Address
│
└── Order Items
    └── Product Snapshot
```

Users can also view previously placed orders.

---

## Entity Framework Core

The application uses multiple EF Core contexts to separate persistence responsibilities:

```text
CatalogDbContext
   └── Catalog entities

BasketDbContext
   └── Basket entities

OrderDbContext
   └── Order entities

AppIdentityDbContext
   └── Identity entities
```

For development, the project currently uses the **Entity Framework Core InMemory provider**.

Example:

```csharp
builder.Services.AddDbContext<CatalogDbContext>(options =>
{
    options.UseInMemoryDatabase("OnlineStore.Catalog");
});
```

---

## Repository Pattern

Data access is abstracted through repository interfaces.

```csharp
IRepository<T>
IAsyncRepository<T>
```

The base repository provides operations including:

```text
Add
AddAsync
Delete
DeleteAsync
GetById
GetByIdAsync
List
ListAsync
ListAll
ListAllAsync
Update
UpdateAsync
```

This keeps persistence logic separated from application services.

---

## Specification Pattern

The project uses specifications for reusable query logic.

Examples include:

```text
Catalog filtering
Basket item loading
Order filtering
Related entity inclusion
```

Conceptually:

```text
CatalogService
      │
      ▼
CatalogFilterSpecification
      │
      ▼
Repository
      │
      ▼
Entity Framework Query
```

This prevents complex filtering logic from being duplicated throughout the application.

---

## Dependency Injection

ASP.NET Core's built-in dependency injection container is used throughout the project.

Examples:

```csharp
builder.Services.AddTransient<ICatalogService, CatalogService>();

builder.Services.AddScoped<IBasketService, BasketService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
```

Repositories and Entity Framework contexts are also resolved through DI.

---

## UI Redesign

The original interface was redesigned into a modern OnlineStore experience.

The updated frontend includes:

* Custom OnlineStore branding
* Modern navigation
* Responsive hero section
* Product cards
* Improved filtering interface
* Modern shopping basket
* Responsive layouts
* Order summary panel
* Improved navigation and calls to action
* Custom dark visual theme

---

## Screenshots

### Catalog

The catalog includes responsive product cards, filtering, pagination, and basket actions.

### Shopping Basket

The basket provides a structured order summary with item prices, quantities, subtotals, and checkout navigation.

> Screenshots can be added to this section as the project evolves.

---

## Getting Started

### Prerequisites

Install a compatible .NET SDK.

The main application projects currently target **.NET 9**.

You can verify your SDK installation with:

```bash
dotnet --version
```

---

### Clone the repository

```bash
git clone https://github.com/DevKanishk/C-.git
```

Move into the project:

```bash
cd C-
```

---

### Restore packages

```bash
dotnet restore
```

---

### Build the solution

```bash
dotnet build OnlineStore.sln
```

A successful build should complete without compilation errors.

---

### Run the application

```bash
dotnet run --project OnlineStore.Web/OnlineStore.Web.csproj
```

The terminal will display the local application URL.

Open that URL in your browser.

---

## Testing

The solution includes an xUnit test project:

```text
OnlineStore.ApplicationCore.Tests
```

Run the tests using:

```bash
dotnet test
```

The tests cover core domain behavior such as basket operations.

---

## Key Concepts Demonstrated

This project demonstrates practical usage of:

* ASP.NET Core MVC
* C#
* Razor Views
* Entity Framework Core
* ASP.NET Core Identity
* Dependency Injection
* Repository Pattern
* Specification Pattern
* Layered Architecture
* Domain Entities
* Aggregate relationships
* LINQ
* Async/Await
* Authentication and authorization
* Catalog filtering
* Pagination
* Basket management
* Checkout workflows
* Order management
* Responsive frontend development
* xUnit testing

---

## Future Improvements

Potential enhancements include:

* SQL Server persistence
* Complete basket quantity modification
* Remove-item functionality
* Product administration dashboard
* Inventory management
* Search functionality
* Product detail pages
* Payment gateway integration
* Docker support
* CI/CD through GitHub Actions
* Cloud deployment
* REST API endpoints
* Additional unit and integration tests

---

## Author

**Kanishk Singh**

Java, React and .NET developer focused on building scalable backend services and full-stack applications.

* GitHub: https://github.com/DevKanishk
* LinkedIn: https://linkedin.com/in/kanishk-singh-dev

---

## Repository

Source code:

https://github.com/DevKanishk/C-
