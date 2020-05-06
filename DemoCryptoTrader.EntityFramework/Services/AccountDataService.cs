using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.EntityFramework.Services
{
    public class AccountDataService : IBasicDataService<Account>
    {
        private readonly DemoCryptoTraderDbContextFactory _contextFactory;
        private readonly NonQuerryDataService<Account> _nonQuerryDataService;

        public AccountDataService(DemoCryptoTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQuerryDataService = new NonQuerryDataService<Account>(contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQuerryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQuerryDataService.Delete(id);
        }

        public async Task<Account> Get(int id)
        {
            using (DemoCryptoTraderDBContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(a => a.CoinTransactions).FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }    
               
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (DemoCryptoTraderDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts.Include(a => a.CoinTransactions).ToListAsync();
                return entities;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQuerryDataService.Update(id, entity);
        }

    }
}
