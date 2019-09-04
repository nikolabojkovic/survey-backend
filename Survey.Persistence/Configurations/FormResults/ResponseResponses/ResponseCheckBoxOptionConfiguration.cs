using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class CehckboxQuestionResponseConfiguration : IEntityTypeConfiguration<CheckBoxQuestionResponse>
    {
        public void Configure(EntityTypeBuilder<CheckBoxQuestionResponse> builder)
        {
            builder.ToTable("CheckBoxQuestionResponses");
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}

