using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Infrastructure.Mapping;

public class RollDBContext : DbContext
{
    protected RollDBContext(DbContextOptions<RollDBContext> options) : base(options)
    {
    }

    public DbSet<Musica> Musicas => Set<Musica>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RollDBContext).Assembly);
    }
}