using DocControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocControl.Infra.Data.EntitiesConfiguration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Code).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Process).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(200).IsRequired();
            builder.Property(p => p.File).HasMaxLength(200).IsRequired();

            builder.HasData(
                new Document(1, 0122, "title test", "process test", "category test", "fileName.pdf"));

        }
    }
}
