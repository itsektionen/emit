const dateFmt = new Intl.DateTimeFormat('sv-SE', {
  weekday: 'short',
  day: 'numeric',
  month: 'short',
  year: 'numeric',
  timeZone: 'Europe/Stockholm'
});

const dateTimeFmt = new Intl.DateTimeFormat('sv-SE', {
  dateStyle: 'medium',
  timeStyle: 'short',
  timeZone: 'Europe/Stockholm'
});

export const dateFormat = (iso: string) => dateFmt.format(new Date(iso));

export const dateTimeFormat = (iso: string) => dateTimeFmt.format(new Date(iso));

// <input type="datetime-local"> wants "YYYY-MM-DDTHH:mm".
// sv-SE prints "YYYY-MM-DD HH:mm:ss", so cut the seconds and swap the space for a T.
export const toLocalInput = (iso: string) =>
  new Date(iso)
    .toLocaleString('sv-SE', { timeZone: 'Europe/Stockholm' })
    .slice(0, 16)
    .replace(' ', 'T');
