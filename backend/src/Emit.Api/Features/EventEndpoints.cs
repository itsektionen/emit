using Emit.Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Emit.Api.Features;

public static class EventEndpoints {
    public static RouteGroupBuilder MapEventEndpoints(this RouteGroupBuilder group) {
        group.MapGet("/{id:guid}", GetEvent);
        group.MapGet("/", GetAllEvents);
        group.MapPost("/", CreateEvent);
        group.MapPut("/{id:guid}", EditEvent);
        group.MapDelete("/{id:guid}", DeleteEvent);
    
        return group;
    }

    public static async Task<Results<Ok<EventDto>, NotFound>> GetEvent(Guid id, EmitDbContext db) {
        var ev = await db.Events
            .Where(e => e.Id == id)
            .Select(e => new EventDto(e.Id, e.Title, e.Description, e.StartsAt, e.EndsAt, e.Location, e.Image))
            .FirstOrDefaultAsync();

        return ev is null ? TypedResults.NotFound() : TypedResults.Ok(ev);
    }

    public static async Task<Ok<List<EventDto>>> GetAllEvents(EmitDbContext db) =>
        TypedResults.Ok(await db.Events
            .OrderBy(e => e.StartsAt)
            .Select(e => new EventDto(e.Id, e.Title, e.Description, e.StartsAt, e.EndsAt, e.Location, e.Image))
            .ToListAsync());

    public static async Task<Created<EventDto>> CreateEvent(CreateEventRequest req, EmitDbContext db) {
        var ev = new Event {
            Title = req.Title,
            Description = req.Description,
            StartsAt = req.StartsAt,
            EndsAt = req.EndsAt,
            Location = req.Location,
            Image = req.Image
        };

        db.Events.Add(ev);
        await db.SaveChangesAsync();

        return TypedResults.Created($"{ev.Id}",
            new EventDto(ev.Id, ev.Title, ev.Description, ev.StartsAt, ev.EndsAt, ev.Location, ev.Image));
    }
    
    public static async Task<Results<NoContent, NotFound, BadRequest>> EditEvent(Guid id, EditEventRequest req, EmitDbContext db) {
        if (req is { Title: null, Description: null, StartsAt: null, EndsAt: null, Location: null, Image: null })
            return TypedResults.BadRequest();
        
        var ev = await db.Events.Where(e => e.Id == id).ExecuteUpdateAsync(s => {
            if (req.Title != null) s.SetProperty(e => e.Title, req.Title);
            if (req.Description != null) s.SetProperty(e => e.Description, req.Description);
            if (req.StartsAt != null) s.SetProperty(e => e.StartsAt, req.StartsAt.Value);
            if (req.EndsAt != null) s.SetProperty(e => e.EndsAt, req.EndsAt.Value);
            if (req.Location != null) s.SetProperty(e => e.Location, req.Location);
            if (req.Image != null) s.SetProperty(e => e.Image, req.Image);
        });

        return ev == 0 ? TypedResults.NotFound() : TypedResults.NoContent();
    }

    public static async Task<Results<NoContent, NotFound>> DeleteEvent(Guid id, EmitDbContext db) {
        var ev = await db.Events.Where(e => e.Id == id).ExecuteDeleteAsync();
        return ev == 0 ? TypedResults.NotFound() : TypedResults.NoContent();
    }
}
