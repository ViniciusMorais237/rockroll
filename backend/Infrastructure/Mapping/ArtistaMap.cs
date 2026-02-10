using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class ArtistaMap : IEntityTypeConfiguration<ArtistaDB>
    {
        public void Configure(EntityTypeBuilder<ArtistaDB> builder)
        {
            builder.ToTable("Artista");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NU_NSU_ARTISTA")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdUsuario)
                .HasColumnName("NU_NSU_CE_USUARIO")
                .HasColumnType("int");

            builder.Property(x => x.Nome)
            .HasColumnName("DES_NOME")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(16);

            builder.Property(x => x.Premium)
                .HasColumnName("IC_PREMIUM")
                .HasColumnType("bit");

            builder.Property(x => x.UrlFoto)
            .HasColumnName("CAMINHO_FOTO")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(150);

            builder.Property(x => x.DtInsercao)
            .HasColumnName("DT_HR_CADASTRO")
            .HasColumnType("datetime");

            builder.Property(x => x.Ativo)
            .HasColumnName("IC_ATIVO")
            .HasColumnType("bit");

        }
    }
}