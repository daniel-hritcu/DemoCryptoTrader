using DemoCryptoTrader.CoinGekoAPI.Models;
using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;



namespace DemoCryptoTrader.CoinGekoAPI.Services
{
    public class CoinIndexService : ICoinIndexService
    {
        static HttpClient client = new HttpClient();
        //Api base uri
        string baseUri = "https://api.coingecko.com/api/v3/";

        public async Task<CoinIndex> GetCoinIndex(CoinIndexId indexId)
        {
            //new null response
            CoinIndex coinIndex = null;
            //Api market uri
            string apiCallUri = "coins/markets?vs_currency=usd&ids=";
            //Full api uri
            string uri = baseUri + apiCallUri + GetSuffix(indexId);

            //Get httpResponse from api
            HttpResponseMessage httpResponse = await client.GetAsync(uri);

            if (httpResponse.IsSuccessStatusCode) 
            {
                //Get json string from httpResponse
                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                //Deserialize the jsonResponse into a response model
                MarketCoinIndex coinIndexResponse = MarketCoinIndex.FromJson(jsonResponse)[0];

                //Return CoinIndex model from Domain layer
                coinIndex = new CoinIndex
                {
                    Price = coinIndexResponse.CurrentPrice,
                    Change = coinIndexResponse.PriceChangePercentage24H,
                    Id = indexId
                };
            }

            return coinIndex;

        }

        private string GetSuffix(CoinIndexId indexId)
        {
            switch (indexId)
            {
                case CoinIndexId.Bitcoin:
                    return "bitcoin";
                case CoinIndexId.Ethereum:
                    return "ethereum";
                case CoinIndexId.Litecoin:
                    return "litecoin";
                default:
                    //TODO: fix this later
                    return "bitcoin";
            }
        }
    }
}