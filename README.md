# Full Stack Minimart Application

## Tech Stack:
- Backend: ASP.NET Core Web API + EF Core + ProgreSQL
	- Project Structure : Use Clean Architecture
		- Domain: Entities (Product, Inventory, User, Permission), business logic
		- Application: Use cases, DTOs, interfaces
		- Infrastructure: EF Core DbContext, repository implementations, ProgreSQL connection
		- API: Controllers, dependency injection, authentication endpoints
	- Entities:
		- Product: Id, Name, Description, Price
		- Inventory: Id, ProductId, Quantity
		- User: Id, Username, PasswordHash, Role
		- Permission: UserId, RoleType
	- EF Core:
		- Configure DbContext with DbSet for each entity
		- Use migrations to create tables in ProsgreSQL
		- Implement repository pattern for data access
	- Authentication:
		- Use JWT for authentication
		- Implement login endpoint to generate JWT token
		- Use middleware to validate JWT token for protected endpoints
- Frontend: Vue.js + Quasar
	- Project Structure: Use Quasar CLI
		- Components: Reusable components for product listing, inventory management, user authentication
		- Pages: Views for home, login, product details, inventory management
		- Store: Vuex store for state management (user authentication, product list)
	- Authentication:
		- Use JWT token for authentication
		- Store token in local storage and include it in API requests
	- UI:
		- Use Quasar components for responsive design
		- Implement product listing with filters and sorting
		- Implement inventory management with add/edit/delete functionality
- Clean Architecture:
	- Backend:
		- Use Clean Architecture principles to separate concerns
			- Domain layer contains business logic and entities
			- Application layer contains use cases and interfaces
			- Infrastructure layer contains data access and external services
			- API layer contains controllers and dependency injection
	- Frontend:
		- Use Vue.js components to separate UI logic
		- Use Vuex store for state management
		- Use Quasar components for responsive design

## Entity Relationships

| Entity       | Relationships                                                                 |
|--------------|-------------------------------------------------------------------------------|
| User         | One-to-Many with UserRole (UserId)                                           |
| Product      | One-to-Many with Inventory (ProductId)                                       |
| Inventory    | Many-to-One with Product (ProductId as foreign key)                         |
| UserRole     | Many-to-One with User (UserId as foreign key), RoleType as Enum             |
| RoleType     | Enum used in UserRole to define roles (e.g., Admin, Cashier)                |

## Database Migrations

To manage database schema changes, follow these steps:

### 1. Add a Migration
To create a new migration, run the following command in the terminal: `dotnet ef migrations add <MigrationName>`
Replace `<MigrationName>` with a descriptive name for the migration, such as `AddProductTable` or `UpdateInventorySchema`.

Example: `dotnet ef migrations add AddInitialTables`
This will generate a migration file in the `MinimartApp.Infrastructure/Migrations` folder.

---

### 2. Update the Database
To apply the migration and update the database schema, run: ` dotnet ef database update --project MinimartApp.Infrastructure --startup-project MinimartApp.Api`

This will apply all pending migrations to the database.

---

### 3. Verify the Changes
- Check your PostgreSQL database to ensure the schema changes have been applied.
- Use tools like `pgAdmin` or `DBeaver` to inspect the database.

---

### 4. Rollback a Migration (Optional)
If you need to revert a migration, use the following command: `dotnet ef database update <PreviousMigrationName>`

Replace `<PreviousMigrationName>` with the name of the migration you want to roll back to.

---

### 5. Remove a Migration (Optional)
If you created a migration by mistake and haven’t applied it yet, you can remove it using: `dotnet ef migrations remove`


---

### Notes
- Ensure the `dotnet-ef` tool is installed globally. If not, install it using: `dotnet tool install --global dotnet-ef`
- Verify that the connection string in `appsettings.json` is correctly configured: `"Host=localhost;Port=5432;Database=minimartdb;Username=yourusername;Password=yourpassword"`
- If your `DbContext` is in a different project (e.g., `MinimartApp.Infrastructure`), specify the startup project: `dotnet ef migrations add <MigrationName> --startup-project ../MinimartApp.Api dotnet ef database update --startup-project ../MinimartApp.Api`
---