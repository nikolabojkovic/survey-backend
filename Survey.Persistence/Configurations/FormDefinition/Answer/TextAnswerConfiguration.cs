using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class TextAnswerConfiguration : IEntityTypeConfiguration<TextAnswer>
    {
        public void Configure(EntityTypeBuilder<TextAnswer> builder)
        {
            builder.ToTable("TextAnswers");
            builder.Property(t => t.Text).HasMaxLength(100);
        }
    }
}

