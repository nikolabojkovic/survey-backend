using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey.Result;

namespace Survey.Persistence.Configurations
{
    public class SurveyResultConfiguration : IEntityTypeConfiguration<SurveyResult>
    {
        public void Configure(EntityTypeBuilder<SurveyResult> builder)
        {
            builder.ToTable("SurveyResults");
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.StartedAt).IsRequired();
            builder.HasOne(t => t.Form)
                 .WithMany(t => t.SurveyResults)
                 .HasForeignKey(t => t.FormId);
        }
    }
}

