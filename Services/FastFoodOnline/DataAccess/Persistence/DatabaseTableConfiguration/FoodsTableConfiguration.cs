using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration
{
    public class FoodsTableConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.Name).HasMaxLength(100);

            builder.Property(f => f.Price).IsRequired();

            builder.Property(f => f.IsActive).HasDefaultValue(true);
            builder.Property(f => f.IsActive).IsRequired();
        }
    }
}
