using DemoCryptoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.Domain.Services
{
    public interface ICoinIndexService
    {
        Task<CoinIndex> GetCoinIndex(CoinIndexId indexId);

        Task<double> GetCoinPrice(string coinId);
    }
}
