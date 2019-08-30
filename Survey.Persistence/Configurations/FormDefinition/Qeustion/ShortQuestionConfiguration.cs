using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ShortQuestionConfiguration : IEntityTypeConfiguration<ShortQuestion>
    {
        public void Configure(EntityTypeBuilder<ShortQuestion> builder)
        {
            builder.ToTable("ShortQuestions");
        }
    }
}

