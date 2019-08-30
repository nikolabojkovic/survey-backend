using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class TextOptionConfiguration : IEntityTypeConfiguration<TextOption>
    {
        public void Configure(EntityTypeBuilder<TextOption> builder)
        {
            builder.ToTable("TextOptions");
            builder.Property(t => t.Text).HasMaxLength(100);
        }
    }
}

