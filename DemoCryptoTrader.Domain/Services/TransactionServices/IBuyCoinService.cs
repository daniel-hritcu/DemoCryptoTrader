using DemoCryptoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.Domain.Services.TransactionServices
{
    public interface IBuyCoinService
    {
        Task<Account> BuyCoin(Account buyer, string coinId, double ammount);
    }
}
