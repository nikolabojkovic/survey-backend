using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Users;

namespace Survey.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Email)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(t => t.Password)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(t => t.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(t => t.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}

