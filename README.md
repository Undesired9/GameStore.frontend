# GameStore.frontend

GameStore.frontend is a Blazor web application (.NET 10) that provides the UI for the Game Store catalog. It consumes the
REST API exposed by [Gamestore.api](https://github.com/Undesired9/gamestore.api).

## Overview

- Technology: .NET 10, ASP.NET Core Blazor Web App
- Rendering: server-side rendering with streaming plus Interactive Server render mode for edit/delete flows
- UI: Bootstrap 5 + Bootstrap Icons (loaded from CDN)
- Purpose: list, create, edit and delete games in a game catalog

## Features

- Game catalog list with genre and price (server-streamed from the API)
- Add a new game via a validated form
- Edit an existing game via a validated form
- Delete a game via a Bootstrap modal (confirmation)
- Pages: `/` (catalog), `/editgame` (new game), `/editgame/{id:int}` (edit game), `/not-found` (404)

## Project structure (key folders)

- `Clients/` — typed `HttpClient` clients that call the API (`GamesClient`, `GenresClient`)
- `Components/` — Blazor components (App, Routes, layout, pages)
- `Models/` — DTOs shared with the UI (`GameSummary`, `GameDetails`, `Genre`)
- `Converters/` — JSON converters (e.g. string/number handling for `GenreId`)
- `wwwroot/` — static assets (`app.css`)

## Getting started

Prerequisites: .NET 10 SDK installed.

1. Clone and run the backend API (it provides the data):

   ```bash
   git clone https://github.com/Undesired9/gamestore.api
   cd gamestore.api
   dotnet run
   ```

   The API runs at `http://localhost:5250` (see `Properties/launchSettings.json`).

2. Set the API base URL in `appsettings.json`:

   ```json
   "ApiUrl": "http://localhost:5250"
   ```

3. Run the frontend:

   ```bash
   dotnet run
   ```

4. Open the app:

   - HTTP: http://localhost:5141
   - HTTPS: https://localhost:7182

## Configuration

- `ApiUrl` — base URL of the Gamestore.api backend. Required; the app throws at startup if it is missing.

## CI/CD

A GitHub Actions workflow (`.github/workflows/ci.yml`) restores, builds, publishes and uploads the app as an artifact
on every push/PR to `main`.

## Tests

No test project is present yet. Once one exists, run tests with:

```bash
dotnet test
```

## License

Public