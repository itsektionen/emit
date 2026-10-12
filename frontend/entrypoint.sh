#!/bin/bash

# Only used in development as an entrypoint for the Docker container

set -e

echo "Starting Emit frontend..."

# Install dependencies into the container's own node_modules volume
pnpm install --frozen-lockfile

# Start the Vite dev server, reachable from outside the container
exec pnpm dev --host 0.0.0.0
