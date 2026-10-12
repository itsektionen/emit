<script lang="ts">
  import { dateFormat } from '#lib/dates.ts';

  let { data } = $props();
</script>

<svelte:head>
  <title>Events | Emit</title>
</svelte:head>

<h1 class="mb-4 text-3xl font-bold">Events</h1>

<div class="grid grid-cols-1 gap-3">
  {#each data.events as ev (ev.id)}
    <a href="/events/{ev.id}" class="relative block h-[40vh] overflow-hidden rounded-lg bg-muted">
      {#if ev.image}
        <img src={ev.image} alt={ev.title} loading="lazy" class="h-full w-full object-cover" />
      {/if}
      <div
        class="absolute inset-x-0 bottom-0 flex items-end justify-between gap-4 bg-linear-to-t from-black to-transparent px-3 pt-10 pb-3 text-sm text-white"
      >
        <div class="space-y-1">
          <p class="leading-none font-medium">{ev.title}</p>
          <p class="leading-none">{ev.location}</p>
        </div>
        <time class="leading-none" datetime={ev.startsAt}>{dateFormat(ev.startsAt)}</time>
      </div>
    </a>
  {:else}
    <p class="text-muted-foreground">No events found</p>
  {/each}
</div>
