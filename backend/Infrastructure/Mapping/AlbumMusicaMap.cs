using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class AlbumMusicaMap : IEntityTypeConfiguration<MusicaAlbumDB>
    {
        public void Configure(EntityTypeBuilder<MusicaAlbumDB> builder)
        {
            builder.ToTable("ALBUM_MUSICA");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("NU_NSU_ALBUM_MUSICA")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(m => m.IdAlbum)
                .HasColumnName("NU_NSU_CE_ALBUM")
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