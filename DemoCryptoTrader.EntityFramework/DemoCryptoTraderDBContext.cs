using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DemoCryptoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.EntityFramework
{
    class DemoCryptoTraderDBContext : DbContext
    {
        //Models to migrate to DB
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CoinTransaction> CoinTransactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*  
             *  Establish a OneToOne relationship between CoinTransaction and CoinAsset
             *  with CoinTransaction.Id beeing the foreign key in CoinAsset table.
             */
            modelBuilder.Entity<CoinTransaction>().OwnsOne(t => t.Coin);

            base.OnModelCreating(modelBuilder);
        }

        /*  
        *  TODO: 
        *  I don't like keeping the connection string hard coded here.
        *  Will resolve in later commit.
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer
                (
                //SQL Server Connection String.
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Database=DemoCryptoTraderDB;" +
                "Integrated Security=True;"
                );

            base.OnConfiguring(optionsBuilder);
        }
    }
}
