using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    class CoinTransaction
    {
        public Account Account { get; set; }
        public bool IsPurchase { get; set; }
        public Coin Coin { get; set; }
        public double Ammount { get; set; }
        public double Price { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
