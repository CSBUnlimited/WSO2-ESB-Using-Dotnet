using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration
{
    public class PaymentsTableConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(p => p.User).WithMany(u => u.Payments).HasForeignKey(p => p.UserId).IsRequired();

            builder.HasOne(p => p.PaymentMethod).WithMany(pm => pm.Payments).HasForeignKey(p => p.PaymentMethodId).IsRequired();

            builder.Property(p => p.ReferenceNumber).IsRequired();
            builder.Property(p => p.ReferenceNumber).HasMaxLength(50);

            builder.Property(p => p.EarnedLoyaltyPoints).IsRequired();

            builder.Property(p => p.Amount).IsRequired();

            builder.Property(p => p.PayedDateTime).HasDefaultValueSql("datetime('now','localtime')");

            builder.HasOne(p => p.SentEmail).WithOne(ce => ce.Payment).HasForeignKey<SentEmail>(se => se.PaymentId);

            builder.HasOne(p => p.SentMessage).WithOne(cs => cs.Payment).HasForeignKey<SentMessage>(sm => sm.PaymentId);

        }
    }
}
