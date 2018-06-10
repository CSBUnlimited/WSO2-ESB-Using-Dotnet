using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration
{
    public class UsersTableConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(20);

            builder.Property(u => u.PasswordHash).IsRequired();

            builder.Property(u => u.PasswordSalt).IsRequired();

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(100);

            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(100);

            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(200);

            builder.Property(u => u.Mobile).IsRequired();
            builder.Property(u => u.Mobile).HasMaxLength(10).IsFixedLength();

            builder.Property(u => u.LoyaltyPoints).HasDefaultValue(0);

            builder.Property(u => u.RegisteredDate).HasDefaultValueSql("datetime('now','localtime')");

            builder.Property(u => u.IsActive).HasDefaultValue(true);
            builder.Property(f => f.IsActive).IsRequired();
        }
    }
}
