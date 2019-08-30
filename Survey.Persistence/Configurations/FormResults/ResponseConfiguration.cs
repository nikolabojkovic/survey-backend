using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ResponseConfiguration : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.ToTable("Responses");
            builder.HasKey(t => t.Id);
            builder.HasMany(t => t.ResponseOptions)
                   .WithOne(t => t.Response)
                   .HasForeignKey(t => t.ResponseId);
            builder.HasOne(t => t.User)
                   .WithMany(t => t.Responses)
                   .HasForeignKey(t => t.UserId);
        }
    }
}

