using Microsoft.EntityFrameworkCore;

namespace Emit.Api.Data;

public class EmitDbContext(DbContextOptions<EmitDbContext> options) : DbContext(options) {
    public DbSet<Event> Events => Set<Event>();
}
