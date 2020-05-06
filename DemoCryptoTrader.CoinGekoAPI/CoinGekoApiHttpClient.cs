using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoCryptoTrader.CoinGekoAPI
{
    class CoinGekoApiHttpClient : HttpClient
    {
        public CoinGekoApiHttpClient()
        {
            //Api base address
            this.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
        }
    }
}
