using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ResponseOptionConfiguration : IEntityTypeConfiguration<ResponseOption>
    {
        public void Configure(EntityTypeBuilder<ResponseOption> builder)
        {
            builder.ToTable("ResponseOptions");
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Response)
                   .WithMany(t => t.ResponseOptions)
                   .HasForeignKey(t => t.ResponseId);
            builder.HasOne(t => t.Option)
                   .WithMany(t => t.ResponsOptions)
                   .HasForeignKey(t => t.OptionId);
        }
    }
}

