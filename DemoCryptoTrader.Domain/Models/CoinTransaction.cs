using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    public class CoinTransaction : DomainObject
    {
        public Account Account { get; set; }
        public bool IsPurchase { get; set; }
        public CoinAsset Coin { get; set; }
        public double Ammount { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
