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
    public DbSet<ArtistaDB> Artistas => Set<ArtistaDB>();
    public DbSet<ArtistaFollowDB> Follow => Set<ArtistaFollowDB>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RollDBContext).Assembly);
    }
}