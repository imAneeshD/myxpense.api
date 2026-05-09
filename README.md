# MyXpense API

MyXpense is a production-ready, enterprise-level .NET 9 backend application designed for managing personal expenses. It is built using **Clean Architecture**, **CQRS**, and **GraphQL**, ensuring scalability, maintainability, and high performance.

## 🚀 Features

- **GraphQL API**: Powered by HotChocolate for flexible and efficient data querying.
- **Clean Architecture**: Decoupled layers for Domain, Application, Infrastructure, and Persistence.
- **CQRS Pattern**: Implemented with MediatR for clear separation of concerns.
- **PostgreSQL + EF Core**: Robust data storage with Code First migrations and UUID support.
- **Soft Delete & Auditing**: Global query filters for soft deletes and automatic audit column population.
- **JWT Authentication**: Secure API access with JSON Web Tokens.
- **Background Jobs**: Automated recurring expense processing.
- **Dashboard Analytics**: Real-time insights into monthly/weekly spending and category breakdowns.
- **Production Grade**: Serilog logging, Global Exception Middleware, and FluentValidation.

## 🛠️ Tech Stack

- **Framework**: .NET 9
- **API Style**: GraphQL (HotChocolate)
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Messaging**: MediatR (CQRS)
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Logging**: Serilog
- **Documentation**: Scalar / OpenAPI

## 📂 Project Structure

```text
src/
 ├── MyXpense.API            # GraphQL Setup, Middleware, Background Services
 ├── MyXpense.Application    # Interfaces, CQRS (Commands/Queries), DTOs, Services
 ├── MyXpense.Domain         # Core Entities, Base Auditable Entity
 ├── MyXpense.Infrastructure # Authentication (JWT), External Services
 ├── MyXpense.Persistence    # DbContext, Configurations, Repositories, Seeding
 └── MyXpense.Shared         # Common utilities and types
```

## 🏁 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Configuration

Update the connection string in `src/MyXpense.API/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=MyXpenseDb;Username=postgres;Password=your_password"
}
```

### Running the Application

1.  Navigate to the root directory.
2.  Run the application:
    ```bash
    dotnet run --project src/MyXpense.API
    ```
3.  The GraphQL IDE (Banana Cake Pop) will be available at `/graphql`.
4.  The API Reference (Scalar) will be available at `/scalar/v1`.

### Default Credentials (Seeded)

- **Email**: `admin@myxpense.com`
- **Password**: `admin@123`

## 📜 License

This project is licensed under the MIT License.
