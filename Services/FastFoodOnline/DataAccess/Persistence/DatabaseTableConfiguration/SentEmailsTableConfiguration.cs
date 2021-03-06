﻿using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration
{
    /// <summary>
    /// SentEmails Table - Configuration
    /// </summary>
    public class SentEmailsTableConfiguration : IEntityTypeConfiguration<SentEmail>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">EntityTypeBuilder</param>
        public void Configure(EntityTypeBuilder<SentEmail> builder)
        {
            builder.HasOne(se => se.Payment).WithOne(p => p.SentEmail).IsRequired();

            builder.HasOne(se => se.User).WithMany(u => u.SentEmails).HasForeignKey(ce => ce.UserId).IsRequired();

            builder.Property(p => p.SentDateTime).HasDefaultValueSql("datetime('now','localtime')");

            builder.Property(p => p.Subject).IsRequired();

            builder.Property(p => p.Message).IsRequired();
        }
    }
}
