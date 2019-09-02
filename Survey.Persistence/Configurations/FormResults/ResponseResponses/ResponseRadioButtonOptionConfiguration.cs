using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ResponseRadioButtonOptionConfiguration : IEntityTypeConfiguration<RadioButtonQuestionResponse>
    {
        public void Configure(EntityTypeBuilder<RadioButtonQuestionResponse> builder)
        {
            builder.ToTable("RadioButtonQuestionResponses");
            builder.Property(t => t.Name)
                  .IsRequired()
                  .HasMaxLength(50);
        }
    }
}

