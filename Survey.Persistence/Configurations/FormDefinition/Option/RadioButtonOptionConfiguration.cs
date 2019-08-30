using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class RadioButtonOptionConfiguration : IEntityTypeConfiguration<RadioButtonOption>
    {
        public void Configure(EntityTypeBuilder<RadioButtonOption> builder)
        {
            builder.ToTable("RadioButtonOptions");
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
        }
    }
}

