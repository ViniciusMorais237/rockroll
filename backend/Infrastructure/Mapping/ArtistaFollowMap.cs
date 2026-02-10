using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class ArtistaFollowMapidUsuario : IEntityTypeConfiguration<ArtistaFollowDB>
    {
        public void Configure(EntityTypeBuilder<ArtistaFollowDB> builder)
        {
            builder.ToTable("ARTISTA_FOLLOW");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("NU_NSU_ARTISTA_FOLLOW")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(f => f.IdArtista)
                .HasColumnName("NU_NSU_CE_ARTISTA")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(f => f.IdUsuario)
                .HasColumnName("NU_NSU_CE_USUARIO_FOLLOW")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(f => f.DataAtualizacao)
               .HasColumnName("DT_HR_ATUALIZACAO")
                .HasColumnType("datetime()")
                .IsRequired();

            builder.Property(f => f.Ativo)
                .HasColumnName("IC_ATIVO")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}