#!/bin/bash

# Only used in development as an entrypoint for the Docker container

set -e

echo "Starting Emit API..."

# Restore the dotnet-ef tool from dotnet-tools.json, and the API's packages
# (dotnet ef reads obj/project.assets.json before it builds, so this must come first)
dotnet tool restore
dotnet restore src/Emit.Api

# Apply any pending migrations (Postgres is already healthy, see depends_on in docker-compose.yml)
dotnet ef database update --project src/Emit.Api

exec dotnet watch run --project src/Emit.Api --no-launch-profile
