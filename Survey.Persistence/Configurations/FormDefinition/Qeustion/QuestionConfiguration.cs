using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Text)
                   .IsRequired()
                   .HasMaxLength(250);
            builder.HasMany(t => t.Answers)
                   .WithOne(t => t.Question)
                   .HasForeignKey(t => t.QuestionId);
        }
    }
}

