# Looking For Games

A web application built with ASP.NET Core MVC to help users discover their next favorite game!

Looking For Games allows users to browse games and genres, search for games based on their preferences, and maintain a personal list of games.

## Features

- **Game catalogue** — Browse available games and view their details.
- **Genres** — Explore games by genre.
- **Custom search** — Find games based on preferences such as genre, difficulty, player options, and game modes.
- **User authentication** — Register an account, log in, and manage access to user-specific features.
- **Favorite games** — Add games to your personal list to find them later.
- **Game and Genre Management** — Create, edit, and delete content according to user permissions.
- **Featured Content** — Discover selected games and genres on the home page.

## Technologies Used

- C#
- .NET 10
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft SQL Server Express
- ASP.NET Core Identity
- Razor Views
- HTML and CSS
- Bootstrap
- Dependency Injection
## Prerequisites

Before running Looking For Games, install the following:

1. **Git** — To clone the repository.
2. **.NET 10 SDK** — Required to restore, build, and run the application. [Download .NET](https://dotnet.microsoft.com/download/dotnet/10.0).
3. **Microsoft SQL Server Express** — The database engine used by the application. [Download SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
4. **SQL Server Management Studio (SSMS)** — Optional, but recommended for managing and inspecting the database. [Download SSMS](https://learn.microsoft.com/en-us/ssms/install/install).

The instructions below assume Windows, SQL Server Express, and a local SQL Server instance named `SQLEXPRESS`.

## Installation and Setup

### 1. Clone the repository

Open a terminal and run:

```powershell
git clone https://github.com/BigFishSpike/GameFinderProject.git
cd GameFinderProject
```

### 2. Configure the database connection

Looking For Games uses SQL Server and reads its connection string from the `ConnectionStrings:DefaultConnection` configuration setting.

Configure the connection string for your local SQL Server instance. For example, in PowerShell:

```powershell
$env:ConnectionStrings__DefaultConnection = "Server=.\SQLEXPRESS;Database=GameFinder;Trusted_Connection=True;Encrypt=False;"
```

Replace `.\SQLEXPRESS` with your SQL Server instance name if necessary.

This environment variable applies to the current PowerShell session. Keep the same terminal open for the remaining setup commands.

### 3. Restore NuGet packages

From the solution root, run:

```powershell
dotnet restore
```

NuGet dependencies are declared in the project files and will be restored automatically.

### 4. Build the solution

```powershell
dotnet build
```

Ensure the solution builds successfully before continuing.

### 5. Install the Entity Framework Core CLI tool

If `dotnet ef` is not already available, install it using:

```powershell
dotnet tool install --global dotnet-ef --version 10.0.13
```

Verify the installation:

```powershell
dotnet ef --version
```

### 6. Create the database

Apply the existing Entity Framework Core migrations:

```powershell
dotnet ef database update --project Data\GameFinder.Data\GameFinder.Data.csproj --startup-project Web\GameFinder\GameFinder.csproj
```

This creates the database schema and applies the migrations in order. Migration-defined seed data is also applied where configured.

**Note:** The database name in the connection string determines which database receives the migrations. If you already have a databased called GameFinder you want to preserve, use a different database name for testing.

### 7. Run the application

```powershell
dotnet run --project Web\GameFinder\GameFinder.csproj
```

Open the local URL displayed in the terminal to access Looking For Games.

## Project Structure

The solution is divided into four projects:

- **GameFinder** — ASP.NET Core MVC web application, controllers, views, and application configuration.
- **GameFinder.Data** — Entity models, Entity Framework Core database context, entity configurations, migrations, and database-related configuration.
- **GameFinder.Services** — Business logic and service implementations used by the web application.
- **GameFinder.Common** — Shared constants and common definitions used across the solution.

The application uses dependency injection to connect the web layer with the service layer and data layer.

## NuGet Packages

NuGet packages are managed through the individual `.csproj` files and restored automatically with `dotnet restore`.

The main libraries used include Entity Framework Core, the SQL Server provider, ASP.NET Core Identity, and the Entity Framework Core tooling.

Individual package versions can be found in the project files.

## Notes

- A compatible .NET 10 SDK and a running SQL Server instance are required.
- The connection string must match your local SQL Server configuration.
- The database can be created using the existing EF Core migrations.
- This project is a work in progress, and additional features and improvements may be introduced in future updates.
