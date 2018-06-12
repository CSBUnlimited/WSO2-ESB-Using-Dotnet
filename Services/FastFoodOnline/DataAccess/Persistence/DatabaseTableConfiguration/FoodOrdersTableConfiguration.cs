using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration
{
    /// <summary>
    /// FoodOrders Table - Configuration
    /// </summary>
    public class FoodOrdersTableConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">EntityTypeBuilder</param>
        public void Configure(EntityTypeBuilder<FoodOrder> builder)
        {
            builder.HasOne(fo => fo.Food).WithMany(f => f.FoodOrders).HasForeignKey(fo => fo.FoodId).IsRequired();

            builder.HasOne(fo => fo.Payment).WithMany(p => p.FoodOrders).HasForeignKey(fo => fo.PaymentId).IsRequired();

            builder.Property(fo => fo.Quantity).IsRequired();
        }
    }
}
