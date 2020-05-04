using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    public enum CoinIndexId
    { 
        Bitcoin,
        Ethereum,
        Litecoin
    }

    public class CoinIndex
    {
        public double Price  { get; set; }
        public double Change { get; set; }
        public CoinIndexId Id { get; set; }

    }
}
