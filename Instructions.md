
- ASP.NET Core Web API
- HotChocolate GraphQL
- Entity Framework Core
- PostgreSQL
- Clean Architecture
- CQRS Pattern
- MediatR
- FluentValidation
- Repository Pattern
- JWT Authentication
- Serilog Logging
- AutoMapper
- Global Exception Middleware
- Dependency Injection
- Code First Approach
- Soft Delete Support
- Audit Columns
- Background Jobs Ready Structure
- Docker Ready
- Scalar / Banana Cake Pop for GraphQL testing

Architecture should be enterprise-level and scalable.

=========================================
PROJECT STRUCTURE
=========================================

Create solution structure like:

src/
 ├── MyXpense.API
 ├── MyXpense.Application
 ├── MyXpense.Domain
 ├── MyXpense.Infrastructure
 ├── MyXpense.Persistence
 └── MyXpense.Shared

=========================================
DATABASE
=========================================

Use PostgreSQL with EF Core Code First migrations.

Configure DbContext properly.

Enable UUID support.

Seed default admin user :
email: admin@myxpense.com
password: admin@123  

=========================================
COMMON BASE ENTITY
=========================================

Create a BaseAuditableEntity with:

- Id (Guid)
- CreatedBy
- CreatedDate
- UpdatedBy
- UpdatedDate
- IsDeleted
- DeletedBy
- DeletedDate

All entities must inherit from this.

=========================================
ENTITIES
=========================================

Create these entities with proper relationships and navigation properties:

1. User
- FullName
- Email
- PasswordHash
- Currency
- TimeZone
- IsActive

2. Tag
- UserId
- Name
- Color
- Icon

3. Expense
- UserId
- TagId
- Title
- Description
- Amount
- ExpenseDate
- PaymentMethod
- IsRecurring

4. RecurringExpense
- UserId
- TagId
- Title
- Description
- Amount
- Frequency
- StartDate
- NextExecutionDate
- AutoCreateExpense
- IsActive

5. Notification
- UserId
- Title
- Message
- NotificationType
- IsRead
- TriggeredAt

6. AlertRule
- UserId
- RuleName
- RuleType
- ThresholdPercentage
- ThresholdAmount
- IsEnabled

7. Budget
- UserId
- TagId
- BudgetName
- MonthlyLimit
- StartMonth
- IsActive

8. DashboardSnapshot
- UserId
- SnapshotMonth
- TotalExpense
- TotalIncome
- HighestExpenseCategory
- AverageDailySpend

=========================================
RELATIONSHIPS
=========================================

User
- HasMany Tags
- HasMany Expenses
- HasMany Notifications
- HasMany Budgets
- HasMany RecurringExpenses

Tag
- HasMany Expenses

=========================================
CQRS IMPLEMENTATION
=========================================

Implement CQRS using MediatR.

Folder structure:

Features/
 ├── Expenses
 │    ├── Commands
 │    ├── Queries
 │    ├── DTOs
 │    ├── Validators
 │    └── Handlers

Create sample:

Expense Features:
- CreateExpenseCommand
- UpdateExpenseCommand
- DeleteExpenseCommand
- GetExpenseByIdQuery
- GetAllExpensesQuery

=========================================
GRAPHQL
=========================================

Use HotChocolate GraphQL.

Implement:
- Query Type
- Mutation Type

Expose:
- Expenses
- Tags
- Dashboard
- Notifications

Add filtering, sorting, and pagination support.

=========================================
VALIDATION
=========================================

Use FluentValidation.

Validate:
- Required fields
- Positive amount
- Valid email
- Date validations

=========================================
AUTHENTICATION
=========================================

Implement JWT authentication.

Add:
- Register
- Login
- Refresh Token structure ready

Secure GraphQL endpoints.

=========================================
SOFT DELETE
=========================================

Global query filters for IsDeleted.

Delete operations should not remove records physically.

=========================================
AUDIT HANDLING
=========================================

Automatically populate:
- CreatedBy
- CreatedDate
- UpdatedBy
- UpdatedDate

Using SaveChanges interceptor or DbContext override.

=========================================
MIDDLEWARE
=========================================

Create:
- Global Exception Middleware
- Request Logging Middleware

=========================================
LOGGING
=========================================

Use Serilog.

Add:
- Console logging
- File logging

=========================================
DATABASE CONFIGURATION
=========================================

Use IEntityTypeConfiguration for all entities.

Apply:
- Constraints
- Indexes
- Relationships
- Decimal precision

=========================================
MIGRATIONS
=========================================

Setup EF Core migrations correctly.

=========================================
DEPENDENCY INJECTION
=========================================

Create clean DI extensions per layer.

=========================================
API CONFIGURATION
=========================================

Configure:
- Swagger
- GraphQL Playground
- CORS
- JWT Authentication
- Health Checks

=========================================
BEST PRACTICES
=========================================

Use:
- Async/Await everywhere
- CancellationToken
- Proper DTO separation
- Response wrappers
- Minimal controller usage
- SOLID principles
- Clean naming conventions

=========================================
EXTRA REQUIREMENTS
=========================================

1. Add seed data for default tags:
- Groceries
- Rent
- Bills
- Travel

2. Add dashboard analytics service:
- Monthly total
- Weekly total
- Yearly comparison
- Category breakdown

3. Add recurring expense scheduler service structure.

4. Add GraphQL subscriptions structure ready for future notifications.

5. Add repository abstractions.

6. Use PostgreSQL UUID primary keys.

7. Configure decimal precision for money fields:
decimal(18,2)

=========================================
EXPECTED OUTPUT
=========================================

Generate:
- Complete architecture
- Entity models
- DbContext
- Configurations
- CQRS handlers
- GraphQL setup
- Authentication setup
- Dependency injection
- Program.cs setup
- Migration setup
- Sample queries and mutations
- Best practice folder structure

The implementation should be scalable, clean, maintainable, and production ready.