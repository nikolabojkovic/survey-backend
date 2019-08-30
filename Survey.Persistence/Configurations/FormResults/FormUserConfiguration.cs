using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Survey;

namespace Survey.Persistence.Configurations
{
    public class FormUserConfiguration : IEntityTypeConfiguration<FormUser>
    {
        public void Configure(EntityTypeBuilder<FormUser> builder)
        {
            builder.ToTable("FormsUsers");
            builder.HasKey(pt => new { pt.FormId, pt.UserId });

            builder
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserForms)
                .HasForeignKey(pt => pt.UserId);

            builder
                .HasOne(pt => pt.Form)
                .WithMany(t => t.FormUsers)
                .HasForeignKey(pt => pt.FormId);
        }
    }
}

