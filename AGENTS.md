# Repository Guidelines

## Project Structure & Module Organization
`catalog-service.sln` is the solution entry point. The application lives in `catalog-service/` and follows a four-layer layout: `domain/` for business logic, `application/Service/` for service contracts, `infrastructure/` for EF Core persistence and mappers, and `adapter/restful/v1/controller/` for HTTP controllers, DTOs, and adapter mappers. Shared runtime configuration is in `catalog-service/appsettings.json`, local launch profiles are in `catalog-service/Properties/launchSettings.json`, and design notes live under `docs/`.

## Build, Test, and Development Commands
Use the SDK pinned in `global.json`.

- `dotnet restore catalog-service.sln` restores NuGet packages.
- `dotnet build catalog-service.sln` compiles the solution.
- `dotnet run --project catalog-service/catalog-service.csproj` starts the API locally.
- `dotnet watch --project catalog-service/catalog-service.csproj run` runs with hot reload.
- `dotnet test catalog-service.sln` runs tests when test projects are added.
- `docker compose up --build` builds and starts the containerized service.

## Coding Style & Naming Conventions
Follow standard C# conventions: 4-space indentation, braces on new lines, and one public type per file. Use `PascalCase` for classes, methods, DTOs, and properties; use `camelCase` for locals and parameters; prefix interfaces with `I` (for example, `IProductService`). Keep controllers thin, put business rules in `domain/`, and keep mapping concerns inside the mapper classes already used by each layer.

## Testing Guidelines
There is no test project in the repository yet. Add new tests in a sibling project such as `catalog-service.Tests/` and include it in `catalog-service.sln`. Prefer xUnit for unit tests and name files after the target class, for example `ProductServiceImpTests.cs`. At minimum, cover service logic, mapper behavior, and controller edge cases before opening a PR.

## Commit & Pull Request Guidelines
Recent history follows Conventional Commits with scope, for example `feat(catalog): implement subcategory CRUD`. Keep that format for `feat`, `fix`, `docs`, and `refactor` changes. Open PRs against the correct Git Flow branch (`develop` or `feature/*`), summarize behavior changes, list verification steps, and link related issues. Include request/response examples or Swagger screenshots when API contracts change.

## Security & Configuration Tips
Do not commit real database credentials. Override `ConnectionStrings__DefaultConnection` with environment variables for local and shared environments, and review `appsettings.json` changes carefully before merging.
