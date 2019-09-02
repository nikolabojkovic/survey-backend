using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Question)
                   .WithMany(t => t.Answers)
                   .HasForeignKey(t => t.QuestionId);
        }
    }
}

