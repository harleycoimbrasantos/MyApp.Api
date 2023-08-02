using Microsoft.EntityFrameworkCore;
using MyApp.Data.Extensions;
using MyApp.Data.Mapping;
using MyApp.Domain.Entities;

namespace MyApp.Data.Context
{
    public class SQLContext : DbContext
    {
           public SQLContext(DbContextOptions<SQLContext> options)
            : base(options) { }

        #region DbSet
        public DbSet<CustomerMovement> CustomerMovements { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMovementMap());
            modelBuilder.ApplyConfiguration(new TransactionTypeMap());
            modelBuilder.SeedDataTransactionType();

            base.OnModelCreating(modelBuilder);
        }
    }
}
