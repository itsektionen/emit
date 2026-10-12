<script lang="ts">
  import './layout.css';
  import favicon from '#lib/assets/favicon.ico';
  import Navbar from '#lib/components/navbar.svelte';
  import Footer from '#lib/components/footer.svelte';

  let { children } = $props();
</script>

<svelte:head>
  <link rel="icon" href={favicon} />
  <title>Emit</title>
</svelte:head>

<div class="flex min-h-screen flex-col">
  <Navbar />
  <main class="container mx-auto w-full flex-1 px-4 py-8">
    {@render children()}
  </main>
  <Footer />
</div>
