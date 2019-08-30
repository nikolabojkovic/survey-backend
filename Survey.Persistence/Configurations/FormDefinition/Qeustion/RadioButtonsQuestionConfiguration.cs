using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class RadioButtonsQuestionConfiguration : IEntityTypeConfiguration<RadioButtonsQuestion>
    {
        public void Configure(EntityTypeBuilder<RadioButtonsQuestion> builder)
        {
            builder.ToTable("RadioButtonsQuestions");
        }
    }
}

