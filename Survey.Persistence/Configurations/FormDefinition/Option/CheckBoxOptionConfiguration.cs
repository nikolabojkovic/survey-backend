using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class CheckBoxOptionConfiguration : IEntityTypeConfiguration<CheckBoxOption>
    {
        public void Configure(EntityTypeBuilder<CheckBoxOption> builder)
        {
            builder.ToTable("CheckBoxOptions");
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
        }
    }
}

