using System.ComponentModel.DataAnnotations;

namespace Emit.Api.Features;

public record EventDto(
    Guid Id,
    string Title,
    string? Description,
    DateTimeOffset StartsAt,
    DateTimeOffset EndsAt,
    string? Location,
    string? Image
);

public record CreateEventRequest(
    [Required, StringLength(200)] string Title,
    [StringLength(2000)] string? Description,
    DateTimeOffset StartsAt,
    DateTimeOffset EndsAt,
    [StringLength(200)] string? Location,
    [StringLength(2000)] string? Image
);

public record EditEventRequest(
    [StringLength(200)] string? Title,
    [StringLength(2000)] string? Description,
    DateTimeOffset? StartsAt,
    DateTimeOffset? EndsAt,
    [StringLength(200)] string? Location,
    [StringLength(2000)] string? Image
);
