import { API_URL } from '$app/env/private';
import { error, fail } from '@sveltejs/kit';
import type { Actions, PageServerLoad } from './$types';
import type { Event } from '#lib/types.ts';

export const load: PageServerLoad = async ({ fetch }) => {
  const res = await fetch(`${API_URL}/api/events`);
  if (!res.ok) error(502, `API returned ${res.status} for GET /api/events`);
  return { events: (await res.json()) as Event[] };
};

export const actions: Actions = {
  create: async ({ request, fetch }) => {
    const form = await request.formData();
    const res = await fetch(`${API_URL}/api/events`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        title: form.get('title'),
        startsAt: new Date(String(form.get('startsAt'))).toISOString(),
        description: form.get('description') || undefined,
        endsAt: new Date(String(form.get('endsAt'))).toISOString(),
        location: form.get('location') || undefined,
        image: form.get('image') || undefined
      })
    });
    if (!res.ok) return fail(res.status, { error: await res.text() });
  },
  delete: async ({ request, fetch }) => {
    const form = await request.formData();
    const id = form.get('id');
    const res = await fetch(`${API_URL}/api/events/${id}`, { method: 'DELETE' });
    if (!res.ok) return fail(res.status, { error: await res.text() });
  },
  edit: async ({ request, fetch }) => {
    const form = await request.formData();
    const id = form.get('id');
    const title = String(form.get('title') ?? '').trim();
    const description = String(form.get('description') ?? '').trim();
    const startsAt = String(form.get('startsAt') ?? '');
    const endsAt = String(form.get('endsAt') ?? '');
    const location = String(form.get('location') ?? '').trim();
    const image = String(form.get('image') ?? '').trim();

    const res = await fetch(`${API_URL}/api/events/${id}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        title: title || undefined,
        description: description || undefined,
        startsAt: startsAt ? new Date(startsAt).toISOString() : undefined,
        endsAt: endsAt ? new Date(endsAt).toISOString() : undefined,
        location: location || undefined,
        image: image || undefined
      })
    });
    if (!res.ok) return fail(res.status, { error: await res.text() });
  }
};
