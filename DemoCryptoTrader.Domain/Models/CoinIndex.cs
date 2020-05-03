using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    public enum CoinIndexId
    { 
        bitcoin,
        etherium
    }

    public class CoinIndex
    {
        public double Price { get; set; }
        public string Changes { get; set; }
        public CoinIndexId Id { get; set; }

    }
}
