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
            builder.HasMany(t => t.Options)
                   .WithOne(t => t.Answer)
                   .HasForeignKey(t => t.AnswerId);
        }
    }
}

