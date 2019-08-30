using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class SectionQuestionConfiguration : IEntityTypeConfiguration<SectionQuestion>
    {
        public void Configure(EntityTypeBuilder<SectionQuestion> builder)
        {
            builder.ToTable("SectionsQuestions");
            builder.HasKey(pt => new { pt.SectionId, pt.QuestionId });

            builder
                .HasOne(pt => pt.Section)
                .WithMany(p => p.SectionQuestions)
                .HasForeignKey(pt => pt.SectionId);

            builder
                .HasOne(pt => pt.Question)
                .WithMany(t => t.QuestionSections)
                .HasForeignKey(pt => pt.QuestionId);
        }
    }
}

