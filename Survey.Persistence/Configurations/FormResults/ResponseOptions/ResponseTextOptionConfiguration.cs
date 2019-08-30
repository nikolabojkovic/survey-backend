using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ResponseTextOptionConfiguration : IEntityTypeConfiguration<ResponseTextOption>
    {
        public void Configure(EntityTypeBuilder<ResponseTextOption> builder)
        {
            builder.ToTable("ResponseTextOptions");
            builder.Property(t => t.Text).HasMaxLength(100);
        }
    }
}

