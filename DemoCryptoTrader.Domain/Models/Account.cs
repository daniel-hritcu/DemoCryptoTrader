using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCryptoTrader.Domain.Models
{
    class Account
    {
        public int Id { get; set; }
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        public ICollection<CoinTransaction> CoinTransactions { get; set; }
    }
}
