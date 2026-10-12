import { defineEnvVars } from '@sveltejs/kit/env';

export const variables = defineEnvVars({
  API_URL: {
    description: 'Base URL of the Emit .NET API',
    schema: (value) => {
      if (!value)
        throw new Error('API_URL must be set (copy frontend/.env.example to frontend/.env)');
      return value;
    }
  }
});
