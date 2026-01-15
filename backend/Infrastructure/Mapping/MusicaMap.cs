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
            builder.ToTable("[RollRock].[dbo].[Musica]");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NU_NSU_MUSICA")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasColumnName("NO_TITULO")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.UrlMusica)
            .HasColumnName("NO_URL_MSC")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(x => x.UrlImagem)
            .HasColumnName("NO_URL_IMG")
            .HasMaxLength(50);

            builder.Property(x => x.DtInsercao)
            .HasColumnName("DT_INSERCAO")
            .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("IC_ATIVO")
                .IsRequired();

        }

    }
}