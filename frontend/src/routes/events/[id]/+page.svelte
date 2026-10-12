<script lang="ts">
  import { CalendarIcon, MapPinIcon } from '@lucide/svelte';
  import { dateFormat } from '#lib/dates.ts';

  let { data } = $props();

  const tickets = [
    { name: 'Chapter member', price: 150, label: null },
    { name: 'Student', price: 200, label: null },
    { name: 'External', price: 250, label: 'Ticket not available' }
  ];
</script>

<svelte:head>
  <title>{data.event.title} | Emit</title>
</svelte:head>

<div class="flex flex-col gap-4">
  <h1 class="text-3xl font-bold">{data.event.title}</h1>
  <div class="grid items-start gap-4 lg:grid-cols-3">
    <div class="flex flex-col gap-4 lg:col-span-2">
      {#if data.event.image}
        <img class="h-[40vh] w-full rounded-lg object-cover" src={data.event.image} alt="" />
      {/if}
      <div class="flex flex-col gap-1 text-muted-foreground">
        <div class="inline-flex items-center gap-2">
          <CalendarIcon class="size-5" />{dateFormat(data.event.startsAt)}
        </div>
        <div class="inline-flex items-center gap-2">
          <MapPinIcon class="size-5" />{data.event.location}
        </div>
      </div>
      <p class="whitespace-pre-wrap">{data.event.description}</p>
    </div>

    <div class="flex w-full flex-col gap-4 lg:sticky lg:top-4">
      <h2 class="text-xl font-semibold">Tickets</h2>
      <div class="flex flex-col gap-3">
        {#each tickets as ticket (ticket.name)}
          <div class="rounded-xl bg-accent">
            <div class="p-4">
              <h3 class="pb-1 font-semibold">{ticket.name}</h3>
              <div class="text-sm text-muted-foreground">{ticket.price} kr</div>
            </div>
            {#if ticket.label}
              <div
                class="rounded-b-xl bg-muted-foreground/5 py-1 text-center text-sm text-muted-foreground"
              >
                {ticket.label}
              </div>
            {/if}
          </div>
        {/each}
      </div>
    </div>
  </div>
</div>
