using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration
{
    public class PaymentMethodsTableConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.Property(pm => pm.Name).IsRequired();
            builder.Property(pm => pm.Name).HasMaxLength(100);

            builder.HasIndex(pm => pm.Code).IsUnique();
            builder.Property(pm => pm.Code).IsRequired();
            builder.Property(pm => pm.Code).HasMaxLength(2);

            builder.Property(pm => pm.IsActive).HasDefaultValue(true);
            builder.Property(f => f.IsActive).IsRequired();
        }
    }
}
