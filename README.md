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

Example of Postman testing:
first lets try to do some operations on SaleOrders
דשךss
In this example we do POST and PUT(update) to our table
![צילום מסך 2024-03-04 012638](https://github.com/ilanBitan/GoodsProject/assets/62257681/47c6a749-0071-4b0e-b9dc-2ca0e200a9f1)
now we see sale #4
![צילום מסך 2024-03-04 012656](https://github.com/ilanBitan/GoodsProject/assets/62257681/d1b8c021-0ef4-4f58-a8ae-f4bd18b4ec8c)
we go to Postman app and see sale #4
![צילום מסך 2024-03-04 030933](https://github.com/ilanBitan/GoodsProject/assets/62257681/926ca580-f404-47d3-a179-a00a3ff1455c)
now we want to add new sale
![צילום מסך 2024-03-04 032223](https://github.com/ilanBitan/GoodsProject/assets/62257681/ff808fa0-73e1-46dc-91b3-9582c4b392da)
we see in the JSON that we got a new sale
![צילום מסך 2024-03-04 032253](https://github.com/ilanBitan/GoodsProject/assets/62257681/dfccdff4-77be-442e-b8ee-428dc4ca5f45)
now we go to see the specific sale (our new #5 sale)
![צילום מסך 2024-03-04 032314](https://github.com/ilanBitan/GoodsProject/assets/62257681/fc2e4e80-7233-4ba0-accb-7e5a6c8eba0f)
now we return to Postman app to update the #5 sale
![צילום מסך 2024-03-04 032802](https://github.com/ilanBitan/GoodsProject/assets/62257681/f445ea5c-9094-42e9-9266-f6154c24c57a)
now we see the change of our update
![צילום מסך 2024-03-04 032822](https://github.com/ilanBitan/GoodsProject/assets/62257681/643d8f3d-3d56-4081-9667-f86f9e4c2eb0)
after we finished check for sale lets try our product orders
and for the last check lets add new document to an empty list of purchase orders
![צילום מסך 2024-03-04 173735](https://github.com/ilanBitan/GoodsProject/assets/62257681/ed0416ea-b213-47ec-85df-873e31ffa0f1)
![צילום מסך 2024-03-04 173755](https://github.com/ilanBitan/GoodsProject/assets/62257681/db7143a9-c859-4c8d-aaf7-3ba21bc98ccd)
now we look at the json and we see that we got a new purchase
![צילום מסך 2024-03-04 173812](https://github.com/ilanBitan/GoodsProject/assets/62257681/b2518570-aa5b-49fd-a5fc-85c0a73ba074)
hope you enjoyed! :)

## Obtaining SQL Script from Source Code

Our project utilizes Entity Framework Core with the Code-First approach for managing the database schema. Follow the steps below to obtain the SQL script for generating tables and seeding initial values:

1. **Model Classes**: Our C# source code includes model classes representing entities in the application, such as `SaleOrder`, `SaleOrderLine`, `PurchaseOrder`, `PurchaseOrderLine`, etc. These classes define the database schema using Entity Framework Core conventions and data annotations.

2. **Entity Framework Migrations**: Entity Framework Core uses migrations to manage changes to the database schema over time. Each migration captures a set of changes, including creating or modifying tables, adding or removing columns, etc.

3. **Generate SQL Script**: We can generate a SQL script representing the current state of the database schema by using the `dotnet ef migrations script` command-line tool provided by Entity Framework Core.

4. **Execution**: Recruiters can execute the generated SQL script against a database server to create tables and populate them with initial data.

To obtain the SQL script from the provided source code:

- Ensure you have the necessary tools installed, including the .NET SDK and Entity Framework Core tools.
- Navigate to the project directory in the command-line interface.
- Run the `dotnet ef migrations script` command to generate the SQL script.
- Save the generated SQL script to a file or copy its contents for execution against your database server.

By following these steps, you can obtain the SQL script from the source code and set up the database schema and initial data required for the application.
