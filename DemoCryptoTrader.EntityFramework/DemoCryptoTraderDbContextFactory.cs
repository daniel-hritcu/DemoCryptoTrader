using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.EntityFramework
{
    public class DemoCryptoTraderDbContextFactory : IDesignTimeDbContextFactory<DemoCryptoTraderDBContext>
    {
        //made CreateDbContext args optional.
        public DemoCryptoTraderDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DemoCryptoTraderDBContext>();

            //SQL Server Connection String.
            options.UseSqlServer
                (
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Database=DemoCryptoTraderDB;" +
                "Integrated Security=True;"
                );

            return new DemoCryptoTraderDBContext(options.Options);
        }
    }
}
