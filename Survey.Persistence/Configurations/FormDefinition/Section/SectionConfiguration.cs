using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");            
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(t => t.Description)
                .HasMaxLength(250);
            builder.HasOne(t => t.Form)
                   .WithMany(t => t.Sections)
                   .HasForeignKey(t => t.FormId);
        }
    }
}

