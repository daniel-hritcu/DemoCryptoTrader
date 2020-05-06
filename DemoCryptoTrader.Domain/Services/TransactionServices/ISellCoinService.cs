using DemoCryptoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.Domain.Services.TransactionServices
{
    public interface ISellCoinService
    {
        Task<Account> SellCoin(Account buyer, string coinId, double ammount);
    }
}
