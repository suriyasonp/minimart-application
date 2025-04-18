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

## Entity Relationship
## Entity Relationships

| Entity       | Relationships                                                                 |
|--------------|-------------------------------------------------------------------------------|
| User         | One-to-Many with UserRole (UserId)                                           |
| Product      | One-to-Many with Inventory (ProductId)                                       |
| Inventory    | Many-to-One with Product (ProductId as foreign key)                         |
| UserRole     | Many-to-One with User (UserId as foreign key), RoleType as Enum             |
| RoleType     | Enum used in UserRole to define roles (e.g., Admin, Cashier)                |

