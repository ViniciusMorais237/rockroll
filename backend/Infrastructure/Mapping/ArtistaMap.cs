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
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
            .HasColumnName("NO_NOME")
            .HasMaxLength(16);

            builder.Property(x => x.Premium)
                .HasColumnName("IC_PREMIUM");

            builder.Property(x => x.UrlFoto)
            .HasColumnName("NO_URL_FOTO")
            .HasMaxLength(150);

            builder.Property(x => x.DtInsercao)
            .HasColumnName("DT_INSERCAO");

            builder.Property(x => x.Ativo)
            .HasColumnName("IC_ATIVO");

        }
    }
}