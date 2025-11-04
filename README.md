# StockQuote API - .NET 9.0 Minimal API

This project is a playground to rewrite the project ReactStockQuote.
ReactStockQute has been written many years ago but the tooling based on
react-scripts is obsolete because it is no more maintained.

Ideas for this playground:
1. rewrite ReactStockQuote with React 19.2 and next.js (still using SPA)
2. Write a blazor app to learn it.
3. Multi providers framework. The current implementation is limited to Yahoo
   Finance API. Other provider could be used like StockUnlock.
4. Develop a GraphQL API using hotchocolate. 
5. Calculate technical indicators (SMA, EMA, MACD, RSI, Bollinger Bands, etc.)


# Author
Lionel Schiepers

# Useful links

| url | description |
| --- | ----------- |
| /openapi/v1.json | OpenAPI description |
| /scalar | OpenAPI interactive playgroud UI |
| /health | health checks status |
| /health-ui | health checks UI |

# TODO

- Add authentication and authorization
- Endpoint that receives any json
- xUnit for integration testing
- Clean architecture
- Event-Driven architecture 
- Domain-Driven design 
- CQRS

# References

[Minimal APIs quick reference](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)\
[10 Things I Do On Every .NET App - Scott Sauber - NDC Oslo 2025](https://www.youtube.com/watch?v=SvcRvolP2NE&t=1513s)\
[ASP.NET Core Integration Testing Best Practices](https://antondevtips.com/blog/asp-net-core-integration-testing-best-practises)\
[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)\
[Central Package Management](https://www.milanjovanovic.tech/blog/central-package-management-in-net-simplify-nuget-dependencies)
```
dotnet tool install CentralisedPackageConverter --global
central-pkg-converter PATH_TO_YOUR_SOLUTION_FOLDER
```
[Static Code Analysis](https://www.milanjovanovic.tech/blog/improving-code-quality-in-csharp-with-static-code-analysis)\
[xUnit v3](https://xunit.net/docs/getting-started/v3/getting-started)
```
dotnet new install xunit.v3.templates
dotnet new xunit3
```
[Getting Started with GraphQL in .NET](https://www.youtube.com/watch?v=YL07NyBXC7M)
```
dotnet new install hotchocolate.templates

Autogenerate GraphQL types from C# classes
1. You need to add the HotChocolate.Types.Analyzers dependency.
2. You need to add Properties/ModuleInfo.cs with the line [assembly: HotChocolate.Module("Types")]
3. AddTypes is automatically generated at build time, meaning the error will go away once you dotnet build.
```