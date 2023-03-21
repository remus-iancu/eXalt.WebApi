using eXalt.DomainApi.Entities;
using Microsoft.EntityFrameworkCore;
using SqlLite.PersistanceLayer.Mapping;

namespace SqlLite.PersistanceLayer
{
    public class ExaltContext : DbContext
    {
        public ExaltContext(DbContextOptions<ExaltContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentException("modelBuilder cannot be null");

            modelBuilder.ApplyConfiguration(new BankAccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTransactionTypeConfiguration());
        }

        public DbSet<BankAccount> BankAccounts{ get; set; }
        public DbSet<AccountTransaction> AccountTransactions{ get; set; }
    }
}