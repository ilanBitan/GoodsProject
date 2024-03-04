# GoodsProject

This project is a .NET Core application for managing sale and purchase orders.

## Prerequisites

Before running the application, ensure you have the following installed:

- ASP.NET Core SDK
- Visual Studio 

## Getting Started

1. Clone the repository:
git clone https://github.com/ilanBitan/GoodsProject.git
2. Navigate to the project directory:
cd GoodsProject
3. Restore dependencies:
dotnet restore
4. Update the database:
dotnet ef database update
5. Run the application:
dotnet run

The application will start running on `https://localhost:{YOUR_PORT}`.

## Using Postman to Test Endpoints

1. Ensure the application is running locally.

2. Import the Postman collection provided in the repository.

3. Open Postman and select the imported collection.

4. Test the endpoints according to the following scenarios:

   - **Add Document**: Send a POST request to create a new document.
   - **Update Document**: Send a PUT request to update an existing document.
   - **Delete Document**: Send a DELETE request to delete a document by ID.
   - **Get Document**: Send a GET request to retrieve a document by ID.

Ensure you provide valid request bodies and parameters according to the expected format.

## Tools
1. ASP.NET Core: The API is developed using ASP.NET Core, a cross-platform framework for building web APIs.

2. Entity Framework Core: Entity Framework Core is used for data access and database operations.

3. Swagger: Swagger, now known as OpenAPI Specification (OAS), is utilized for API documentation. It provides interactive documentation for the API endpoints.

4. Postman: Postman is used for testing the API endpoints and verifying their functionality.

Endpoints
The API provides the following endpoints:

POST /api/sale: Create a new sale document.
**




