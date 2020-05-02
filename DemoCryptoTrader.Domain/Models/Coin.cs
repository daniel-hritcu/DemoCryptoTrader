using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    class Coin
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Usd { get; set; }
    }
}
