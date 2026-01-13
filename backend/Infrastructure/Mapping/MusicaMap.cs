using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infrastructure.Mapping
{
    public class MusicaMap : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("[RollRock].[dbo].[Musica]");

            builder.HasKey(x => x.Id);

            builder.Property(x => x)
                .HasMaxLength(50)
                .IsRequired();
        }

    }
}