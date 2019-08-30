using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class ResponseRadioButtonOptionConfiguration : IEntityTypeConfiguration<ResponseRadioButtonOption>
    {
        public void Configure(EntityTypeBuilder<ResponseRadioButtonOption> builder)
        {
            builder.ToTable("ResponseRadioButtonOptions");
        }
    }
}

