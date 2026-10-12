<script lang="ts">
  import { page } from '$app/state';
  import { LogInIcon } from '@lucide/svelte';
  import Logo from '#lib/assets/logo.svg?component';

  const links = [
    { label: 'Events', href: '/events' },
    { label: 'About', href: '/about' }
  ];
</script>

<nav class="border-b bg-card">
  <div class="container mx-auto flex h-14 items-center gap-6 px-4">
    <a href="/">
      <Logo class="h-10 w-auto" aria-label="emit logo" />
    </a>
    <div class="flex gap-1">
      {#each links as link (link.href)}
        <a
          href={link.href}
          aria-current={page.url.pathname === link.href ? 'page' : undefined}
          class="rounded-md px-3 py-1.5 text-sm font-medium text-muted-foreground hover:text-primary aria-[current=page]:bg-accent aria-[current=page]:text-accent-foreground"
        >
          {link.label}
        </a>
      {/each}
    </div>
    <a
      href="/admin"
      aria-label="Admin"
      class="ml-auto px-3 py-1.5 text-muted-foreground hover:text-primary"
    >
      <LogInIcon />
    </a>
  </div>
</nav>
