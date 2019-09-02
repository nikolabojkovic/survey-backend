using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ResponseTextOptionConfiguration : IEntityTypeConfiguration<TextQuestionResponse>
    {
        public void Configure(EntityTypeBuilder<TextQuestionResponse> builder)
        {
            builder.ToTable("TextQuestionResponses");
            builder.Property(t => t.Text).HasMaxLength(100);
        }
    }
}

