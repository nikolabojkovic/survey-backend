using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class CheckBoxAnswerConfiguration : IEntityTypeConfiguration<CheckBoxAnswer>
    {
        public void Configure(EntityTypeBuilder<CheckBoxAnswer> builder)
        {
            builder.ToTable("CheckBoxAnswers");
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
        }
    }
}

