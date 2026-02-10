using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class PlaylistMusicaMap : IEntityTypeConfiguration<MusicaPlaylistDB>
    {
        public void Configure(EntityTypeBuilder<MusicaPlaylistDB> builder)
        {
            builder.ToTable("PLAYLIST_MUSICA");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("NU_NSU_PLAYLIST_MUSICA")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

                builder.Property(m => m.IdPlaylist)
                .HasColumnName("NU_NSU_CE_PLAYLIST")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(m => m.IdMusica)
                .HasColumnName("NU_NSU_CE_MUSICA")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(m => m.DtAtualizacao)
                .HasColumnName("DT_HR_ATUALIZACAO")
                .HasColumnType("datetime")
                .IsRequired();

                builder.Property(m => m.Ativo)
                .HasColumnName("IC_ATIVO")
                .HasColumnType("bit")
                .IsRequired();

        }
    }
}