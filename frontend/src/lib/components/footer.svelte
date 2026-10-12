<script lang="ts">
  import Logo from '#lib/assets/logo.svg?component';
  import GithubIcon from '#lib/assets/github.svg?component';
  import ItChapterIcon from '#lib/assets/it-chapter.svg?component';

  const currentYear = new Date().getFullYear();
</script>

<footer class="border-t">
  <div class="container mx-auto p-6">
    <div class="mb-8 flex justify-between">
      <Logo class="h-10 w-auto" aria-label="emit logo" />

      <div class="flex items-center gap-2">
        <a
          aria-label="github"
          rel="noopener noreferrer"
          target="_blank"
          href="https://github.com/itsektionen"
        >
          <GithubIcon class="size-6 fill-primary transition hover:fill-accent" aria-hidden="true" />
        </a>
        <a
          aria-label="it-chapter website"
          rel="noopener noreferrer"
          target="_blank"
          href="https://kth.it"
        >
          <ItChapterIcon
            class="size-6 fill-primary transition hover:fill-accent"
            aria-hidden="true"
          />
        </a>
      </div>
    </div>

    <div class="flex flex-col items-start justify-between gap-4 sm:flex-row sm:items-center">
      <p class="text-xs text-muted-foreground">
        Copyright &copy; {currentYear} Kongliga Sektionen för Informationsteknik.
      </p>
      <div class="flex flex-col">
        <a href="/terms" class="text-xs text-muted-foreground underline-offset-4 hover:underline">
          Terms of Service
        </a>
        <a
          href="https://kth.it/privacy"
          rel="noopener noreferrer"
          target="_blank"
          class="text-xs text-muted-foreground underline-offset-4 hover:underline"
        >
          Privacy Policy
        </a>
      </div>
    </div>
  </div>
</footer>
