import { API_URL } from '$app/env/private';
import { error } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';
import type { Event } from '#lib/types.ts';

export const load: PageServerLoad = async ({ fetch, params }) => {
  const res = await fetch(`${API_URL}/api/events/${params.id}`);
  if (res.status === 404) error(404, 'event not found');
  if (!res.ok) error(502, `API returned ${res.status}`);
  return { event: (await res.json()) as Event };
};
