using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class RadioButtonAnswerConfiguration : IEntityTypeConfiguration<RadioButtonAnswer>
    {
        public void Configure(EntityTypeBuilder<RadioButtonAnswer> builder)
        {
            builder.ToTable("RadioButtonAnswers");
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
        }
    }
}

