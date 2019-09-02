using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class QuestionResponseConfiguration : IEntityTypeConfiguration<QuestionResponse>
    {
        public void Configure(EntityTypeBuilder<QuestionResponse> builder)
        {
            builder.ToTable("QuestionResponses");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.User)
                   .WithMany(t => t.QuestionResponses)
                   .HasForeignKey(t => t.UserId);
            builder.HasOne(t => t.Form)
                   .WithMany(t => t.QuestionResponses)
                   .HasForeignKey(t => t.FormId);
            builder.HasOne(t => t.Question)
                   .WithMany(t => t.QuestionResponses)
                   .HasForeignKey(t => t.QuestionId);
        }
    }
}

