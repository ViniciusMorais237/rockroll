using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class MusicaMap : IEntityTypeConfiguration<MusicaDB>
    {
        public void Configure(EntityTypeBuilder<MusicaDB> builder)
        {
            builder.ToTable("MUSICA");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NU_NSU_MUSICA")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdArtista)
            .HasColumnName("NU_NSU_CE_ARTISTA")
            .HasColumnType("int");

            builder.Property(x => x.Titulo)
                .HasColumnName("DES_TITULO")
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.UrlMusica)
            .HasColumnName("DES_CAMINHO_AUDIO")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(x => x.UrlImagem)
            .HasColumnName("DES_CAMINHO_IMG")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(50);

            builder.Property(x => x.DtInsercao)
            .HasColumnName("DT_HR_CADASTRO")
            .HasColumnType("datetime")
            .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("IC_ATIVO")
                .HasColumnType("bit")
                .IsRequired();
        }

    }
}