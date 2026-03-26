using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioDB>
    {
        public void Configure(EntityTypeBuilder<UsuarioDB> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.IdUsuario)
                .HasColumnName("NU_NSU_USUARIO")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnName("NO_NOME")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("NO_EMAIL")
                .HasColumnType("nvarchar(125)")
                .IsRequired();

            builder.Property(u => u.SenhaHash)
                .HasColumnName("NU_HASHPASS")
                .HasColumnType("nvarchar(125)")
                .IsRequired();

            
            builder.Property(u => u.IsArtista)
                .HasColumnName("IC_ARTISTA")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(u => u.NomeArquivoImagem)
                .HasColumnName("NO_ARQUIVO_IMG")
                .HasColumnType("nvarchar(125)");

        }
    }
}