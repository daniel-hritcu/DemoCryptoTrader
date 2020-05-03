using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.EntityFramework.Services
{
    class GenericDataService<T> : IBasicDataService<T> where T : DomainObject
    {
        /*
         * We use DbContextFactory instead of DBContext here.
         * 
         * Entity framwork's DBContext is not thread safe, so
         * this way we create a DBContext for each operation to
         * avoid problems with multiple threads.
         */
        private readonly DemoCryptoTraderDbContextFactory _contextFactory;

        public GenericDataService(DemoCryptoTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }


        /*
         * CRUD Operations
         * 
         * We use async functions to avoid locking our
         * UI durring CRUD operations.
         * 
         * TODO:
         *  Implement error handling.
        */

        public async Task<T> Create(T entity)
        {
            using (DemoCryptoTraderDBContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (DemoCryptoTraderDBContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (DemoCryptoTraderDBContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (DemoCryptoTraderDBContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (DemoCryptoTraderDBContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
