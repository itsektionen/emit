<script lang="ts">
  import { enhance } from '$app/forms';
  import Button from '#lib/components/elements/button.svelte';
  import EventForm from '#lib/components/event-form.svelte';
  import { dateTimeFormat } from '#lib/dates.ts';

  let { data, form } = $props();
</script>

<svelte:head>
  <title>Admin | Emit</title>
</svelte:head>

<h1 class="text-3xl font-bold">Events</h1>

<ul class="mt-4 divide-y rounded-lg border bg-card text-card-foreground">
  {#each data.events as ev (ev.id)}
    <li class="flex justify-between gap-4 px-4 py-3">
      <span class="font-medium">{ev.title}</span>
      <time class="text-sm text-muted-foreground" datetime={ev.startsAt}>
        {dateTimeFormat(ev.startsAt)}
      </time>
      <form method="POST" action="?/delete" use:enhance>
        <Button name="id" value={ev.id} variant="danger">Delete</Button>
      </form>
      <EventForm action="?/edit" event={ev} submitLabel="Edit" />
    </li>
  {:else}
    <li class="px-4 py-3 text-muted-foreground">No events yet</li>
  {/each}
</ul>

<h2 class="mt-8 text-lg font-semibold">Create event</h2>
<EventForm action="?/create" submitLabel="Create" />

{#if form?.error}<p class="mt-2 text-sm text-destructive">{form.error}</p>{/if}
