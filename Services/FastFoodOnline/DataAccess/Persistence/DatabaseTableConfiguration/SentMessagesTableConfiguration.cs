using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration
{
    /// <summary>
    /// SentMessages Table - Configuration
    /// </summary>
    public class SentMessagesTableConfiguration : IEntityTypeConfiguration<SentMessage>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">EntityTypeBuilder</param>
        public void Configure(EntityTypeBuilder<SentMessage> builder)
        {
            builder.HasOne(cs => cs.Payment).WithOne(p => p.SentMessage).IsRequired();

            builder.HasOne(cs => cs.User).WithMany(u => u.SentMessages).HasForeignKey(cs => cs.UserId).IsRequired();

            builder.Property(p => p.SentDateTime).HasDefaultValueSql("datetime('now','localtime')");

            builder.Property(p => p.Message).IsRequired();
        }
    }
}
