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
    public DbSet<PlaylistDB> Playlist => Set<PlaylistDB>();
    public DbSet<MusicaPlaylistDB> MusicaPlaylist => Set<MusicaPlaylistDB>();
    public DbSet<AlbumDB> Albuns => Set<AlbumDB>();
    public DbSet<MusicaAlbumDB> MusicaAlbum => Set<MusicaAlbumDB>();
    public DbSet<ArtistaDB> Artistas => Set<ArtistaDB>();
    public DbSet<UsuarioDB> Usuarios => Set<UsuarioDB>();
    public DbSet<ArtistaFollowDB> Follow => Set<ArtistaFollowDB>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RollDBContext).Assembly);
    }
}