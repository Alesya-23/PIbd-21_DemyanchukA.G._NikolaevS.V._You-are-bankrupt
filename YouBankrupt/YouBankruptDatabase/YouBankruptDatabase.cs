using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptDatabaseImplement.Models;

namespace YouBankruptDatabaseImplement
{
    public class YouBankruptDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TechiqueShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Crediting> Creditings { set; get; }

        public virtual DbSet<Payment> Payments { set; get; }

        public virtual DbSet<TransactionWithCustomer> TransactionWithCustomers { set; get; }
    }
}