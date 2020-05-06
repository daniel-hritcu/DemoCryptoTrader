using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DemoCryptoTrader.Domain.Exceptions
{
    public class InvalidCoinIdException : Exception
    {
        public string CoinId { get; set; }

        public InvalidCoinIdException(string coinId)
        {
            CoinId = coinId;
        }

        public InvalidCoinIdException(string coinId, string message) : base(message)
        {
            CoinId = coinId;
        }

        public InvalidCoinIdException(string coinId, string message, Exception innerException) : base(message, innerException)
        {
            CoinId = coinId;
        }
    }
}
