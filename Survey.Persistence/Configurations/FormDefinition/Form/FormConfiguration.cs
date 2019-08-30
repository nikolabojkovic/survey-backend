using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable("Forms");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.HasMany(t => t.Sections)
                   .WithOne(t => t.Form)
                   .HasForeignKey(t => t.FormId);
        }
    }
}

