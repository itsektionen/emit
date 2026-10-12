namespace Emit.Api.Data;

public class Event {
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }
    public string? Location { get; set; }
    public string? Image { get; set; }
}
