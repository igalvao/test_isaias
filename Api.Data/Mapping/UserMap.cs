using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class LegalCaseMap : IEntityTypeConfiguration<LegalCaseEntity>
    {
        public void Configure(EntityTypeBuilder<LegalCaseEntity> builder)
        {
            builder.ToTable("LegalCase");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.CourtName)
                   .IsUnique();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(u => u.CourtName)
                   .HasMaxLength(100);
        }
    }
}
