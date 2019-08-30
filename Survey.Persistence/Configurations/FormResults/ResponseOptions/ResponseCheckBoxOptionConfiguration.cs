using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ResponseCheckBoxOptionConfiguration : IEntityTypeConfiguration<ResponseCheckBoxOption>
    {
        public void Configure(EntityTypeBuilder<ResponseCheckBoxOption> builder)
        {
            builder.ToTable("ResponseCheckBoxOptions");
        }
    }
}

