using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Answer)
                   .WithMany(t => t.Options)
                   .HasForeignKey(t => t.AnswerId);
        }
    }
}

