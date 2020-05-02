using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    public class CoinAsset
    { 
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
