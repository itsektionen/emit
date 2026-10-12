# Emit
This repository contains the source code for Emit, the **E**vent **M**anager for the **IT**-Chapter.

The platform is built using .NET with the Entity Framework Core library, and Svelte for its frontend.

## Development

### Prerequisites

You will need:

- Docker
- Docker Compose
- pnpm
- .NET SDK

> [!NOTE]  
> pnpm and .NET SDK are necessary for development, but are not needed to open a dev server

### Setup

1. Clone this repository
2. Copy the frontend environment file: `cp frontend/.env.example frontend/.env`

Then start the development server with `docker compose up`

### Contributing

Before pushing changes, make sure to:
1. Run `pnpm format` followed by `pnpm lint && pnpm check` in `/frontend`
2. Run `dotnet build` in `/backend`
