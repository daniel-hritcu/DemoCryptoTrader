using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DemoCryptoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.EntityFramework
{
    public class DemoCryptoTraderDBContext : DbContext
    {
        //Models to migrate to DB
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CoinTransaction> CoinTransactions { get; set; }
        public DbSet<User> Users { get; set; }

        /* 
         * We use this constructor to pass the SQL Connection,
         * using the DBContextFactory implementation. This way is more elegant.
         * Now, we don't need to override OnConfiguring anymore.
        */
        public DemoCryptoTraderDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*  
             *  Embedd the CoinAsset in the CoinTransaction table, instead of creating a new table.
             */
            modelBuilder.Entity<CoinTransaction>().OwnsOne(t => t.Coin);

            base.OnModelCreating(modelBuilder);
        }
    }
}
