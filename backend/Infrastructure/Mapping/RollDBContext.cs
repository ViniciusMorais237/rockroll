using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Mapping;

public class RollDBContext : DbContext
{
    public RollDBContext(DbContextOptions<RollDBContext> options) : base(options)
    {
    }
    public DbSet<MusicaDB> Musicas => Set<MusicaDB>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RollDBContext).Assembly);
    }
}