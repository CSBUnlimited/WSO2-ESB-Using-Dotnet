using FastFoodOnline.DataAccess.Persistence.DatabaseTableConfiguration;
using FastFoodOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodOnline.DataAccess.Persistence
{
    /// <summary>
    /// Entity Framework DbContext
    /// </summary>
    public class FastFoodDbContext : DbContext
    {
        #region DbSets
        /// <summary>
        /// Users - DbSet
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Foods - DbSet
        /// </summary>
        public DbSet<Food> Foods { get; set; }
        /// <summary>
        /// PaymentMethods - DbSet
        /// </summary>
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        /// <summary>
        /// Payments - DbSet
        /// </summary>
        public DbSet<Payment> Payments { get; set; }
        /// <summary>
        /// FoodOrders - DbSet
        /// </summary>
        public DbSet<FoodOrder> FoodOrders { get; set; }
        /// <summary>
        /// SentEmails - DbSet
        /// </summary>
        public DbSet<SentEmail> SentEmails { get; set; }
        /// <summary>
        /// SentMessages - DbSet
        /// </summary>
        public DbSet<SentMessage> SentMessages { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">DbContextOptions</param>
        public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options)
        { }

        /// <summary>
        /// Override OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder</param>
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
