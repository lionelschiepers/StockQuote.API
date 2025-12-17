# Project Overview

This project is a .NET 10.0 Minimal API for fetching stock quotes. It's designed as a playground for various technologies, including:

*   **Frontend:** The project is intended to be used with a React or Blazor frontend.
*   **Multiple Quote Providers:** The API is designed to be extensible with multiple quote providers. The current implementation includes a provider for Yahoo Finance and a placeholder for StockUnlock.
*   **GraphQL:** The project uses HotChocolate to provide a GraphQL API.
*   **MediatR:** The project uses the mediator pattern with MediatR.
*   **Clean Architecture:** The project is structured with a clean architecture in mind, with a clear separation of concerns between the API, application, and domain layers.

# Building and Running

## Building the project

To build the project, run the following command from the root directory:

```bash
dotnet build
```

## Running the project

To run the project, run the following command from the `StockQuote.Service` directory:

```bash
dotnet run
```

## Running tests

To run the integration tests, run the following command from the root directory:

```bash
dotnet test
```

# Development Conventions

*   **Central Package Management:** The project uses Central Package Management to manage NuGet dependencies.
*   **Static Code Analysis:** The project is configured with static code analysis to improve code quality.
*   **GraphQL:** The project uses HotChocolate for GraphQL. The GraphQL schema is generated from C# classes.
*   **Minimal APIs:** The project uses .NET Minimal APIs for the REST endpoints.
*   **MediatR:** The project uses MediatR to decouple the request handling from the business logic.
*   **Interfaces:** The project uses interfaces to define the contracts for the quote providers and other services. This allows for easy extensibility and testing.
