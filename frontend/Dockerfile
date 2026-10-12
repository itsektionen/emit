# DEVELOPMENT DOCKERFILE, NOT FOR PRODUCTION
# Only provides Node and pnpm; the source is bind-mounted and run with `pnpm dev` (see entrypoint.sh)
FROM node:26-slim

# Node 25+ no longer ships corepack, so install pnpm directly
RUN npm install -g pnpm@12

EXPOSE 5173

WORKDIR /app
