<script lang="ts">
  import { enhance } from '$app/forms';
  import Button from '#lib/components/elements/button.svelte';
  import { toLocalInput } from '#lib/dates.ts';
  import type { Event } from '#lib/types.ts';

  type Props = { action: string; submitLabel: string; event?: Event };

  let { action, submitLabel, event }: Props = $props();

  const field = 'rounded-md border border-input bg-card px-3 py-1.5 text-sm';
</script>

<form method="POST" {action} use:enhance class="mt-2 flex flex-wrap gap-2">
  {#if event}
    <input type="hidden" name="id" value={event.id} />
  {/if}
  <input name="title" value={event?.title} placeholder="Title" required class={field} />
  <input
    name="startsAt"
    type="datetime-local"
    value={event && toLocalInput(event.startsAt)}
    required
    class={field}
  />
  <input
    name="endsAt"
    type="datetime-local"
    value={event && toLocalInput(event.endsAt)}
    required
    class={field}
  />
  <input name="location" value={event?.location} placeholder="Location" class={field} />
  <input name="image" type="url" value={event?.image} placeholder="Image URL" class={field} />
  <textarea
    name="description"
    value={event?.description}
    placeholder="Description"
    class="w-full {field}"></textarea>
  <Button>{submitLabel}</Button>
</form>
