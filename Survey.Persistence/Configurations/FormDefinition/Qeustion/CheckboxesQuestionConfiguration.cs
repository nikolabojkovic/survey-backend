using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class CheckBoxesQuestionConfiguration : IEntityTypeConfiguration<CheckBoxesQuestion>
    {
        public void Configure(EntityTypeBuilder<CheckBoxesQuestion> builder)
        {
            builder.ToTable("CheckBoxesQuestions");
        }
    }
}

