<script lang="ts">
  import type { HTMLButtonAttributes } from 'svelte/elements';

  type Props = HTMLButtonAttributes & { variant?: 'primary' | 'danger' };

  let { variant = 'primary', class: className, children, ...rest }: Props = $props();

  const variants = {
    primary: 'bg-primary text-primary-foreground hover:bg-primary/90',
    danger: 'bg-destructive text-destructive-foreground hover:bg-destructive/90'
  };
</script>

<button
  class={[
    'rounded-md px-3 py-1.5 text-sm font-medium transition-colors disabled:opacity-50',
    variants[variant],
    className
  ]}
  {...rest}
>
  {@render children?.()}
</button>
