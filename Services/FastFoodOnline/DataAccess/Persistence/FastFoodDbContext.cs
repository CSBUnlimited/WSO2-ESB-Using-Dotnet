using FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Persistence
{
    public class FastFoodDbContext : DbContext
    {
        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<SentEmail> SentEmails { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }

        #endregion

        public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Database Table Configuration

            modelBuilder.ApplyConfiguration(new UsersTableConfiguration());
            modelBuilder.ApplyConfiguration(new FoodsTableConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodsTableConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsTableConfiguration());
            modelBuilder.ApplyConfiguration(new FoodOrdersTableConfiguration());
            modelBuilder.ApplyConfiguration(new SentEmailsTableConfiguration());
            modelBuilder.ApplyConfiguration(new SentMessagesTableConfiguration());

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
