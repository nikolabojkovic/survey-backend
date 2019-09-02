using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class CehckboxQuestionResponseConfiguration : IEntityTypeConfiguration<CehckBoxQuestionResponse>
    {
        public void Configure(EntityTypeBuilder<CehckBoxQuestionResponse> builder)
        {
            builder.ToTable("CehckBoxQuestionResponses");
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}

