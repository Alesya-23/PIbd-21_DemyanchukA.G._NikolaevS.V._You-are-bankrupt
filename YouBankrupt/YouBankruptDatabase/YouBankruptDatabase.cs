using Microsoft.EntityFrameworkCore;
using YouBankruptDatabaseImplements.Models;
using YouBankruptDatabaseImplements.Models;

namespace YouBankruptDatabaseImplements
{
    class YouBankruptDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=YouBankruptDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Currence> Currences { set; get; }

        public virtual DbSet<PurchasesCurrence> PurchasesCurrences { set; get; }

        public virtual DbSet<CreditProgram> CreditPrograms { set; get; }

        public virtual DbSet<Supplier> Suppliers { set; get; }

        public virtual DbSet<CreditProgramCurrence> CreditProgramCurrences { set; get; }

        public virtual DbSet<PurchasesCurrenceCurrence> PurchasesCurrenceCurrences { set; get; }

        public virtual DbSet<Crediting> Creditings { set; get; }

        public virtual DbSet<Payment> Payments { set; get; }

        public virtual DbSet<TransactionWithCustomer> TransactionWithCustomers { set; get; }
    }
}