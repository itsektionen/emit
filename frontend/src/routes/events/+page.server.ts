import { API_URL } from '$app/env/private';
import { error } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';
import type { Event } from '#lib/types.ts';

export const load: PageServerLoad = async ({ fetch }) => {
  const res = await fetch(`${API_URL}/api/events`);
  if (!res.ok) error(502, `API returned ${res.status}`);
  return { events: (await res.json()) as Event[] };
};
