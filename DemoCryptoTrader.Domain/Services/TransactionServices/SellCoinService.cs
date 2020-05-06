using DemoCryptoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.Domain.Services.TransactionServices
{
    public class SellCoinService : ISellCoinService
    {
        private readonly ICoinIndexService _coinIndexService;
        private readonly IBasicDataService<Account> _accountService;

        public SellCoinService(ICoinIndexService coinIndexService, IBasicDataService<Account> accountService)
        {
            _coinIndexService = coinIndexService;
            _accountService = accountService;
        }

        public async Task<Account> SellCoin(Account buyer, string coinId, double ammount)
        {
            double coinPrice = await _coinIndexService.GetCoinPrice(coinId);

            double transactionPrice = coinPrice * ammount;

            CoinTransaction transaction = new CoinTransaction()
            {
                Account = buyer,
                Coin = new CoinAsset()
                {
                    Name = coinId,
                    Price = coinPrice
                },
                DateProcessed = DateTime.Now,
                Ammount = ammount,
                IsPurchase = false
            };

            buyer.CoinTransactions.Add(transaction);
            buyer.Balance += transactionPrice;

            await _accountService.Update(buyer.Id, buyer);

            return buyer;
        }
    }
}
