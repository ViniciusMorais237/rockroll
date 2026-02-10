using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class PlaylistMap : IEntityTypeConfiguration<PlaylistDB>
    {
        public void Configure(EntityTypeBuilder<PlaylistDB> builder)
        {
            builder.ToTable("PLAYLIST");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("NU_NSU_PLAYLIST")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdUsuario)
                .HasColumnName("NU_NSU_CE_USUARIO_PLAYLIST")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Titulo)
                .HasColumnName("DES_TITULO")
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Imagem)
                .HasColumnName("DES_CAMINHO_IMG")
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.DtInsercao)
                .HasColumnName("DT_HR_CRIACAO")
                .HasColumnType("datetime()")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("IC_ATIVO")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}