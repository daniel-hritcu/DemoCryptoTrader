using DemoCryptoTrader.CoinGekoAPI.Models;
using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;



namespace DemoCryptoTrader.CoinGekoAPI.Services
{
    public class CoinIndexService : ICoinIndexService
    {

        public async Task<CoinIndex> GetCoinIndex(CoinIndexId indexId)
        {
            string baseUri = "https://api.coingecko.com/api/v3/coins/markets?";
            string apiCallUri = "vs_currency=usd&ids=";
            string uri = baseUri + apiCallUri + GetSuffix(indexId);

            using (HttpClient client = new HttpClient())
            {
                //Get httpResponse from api
                HttpResponseMessage httpResponse = await client.GetAsync("bitcoin");

                //Get json string from httpResponse
                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                //Deserialize the jsonResponse into a response model
                MarketCoinIndex coinIndexResponse = MarketCoinIndex.FromJson(jsonResponse)[0];

                //Return CoinIndex model from Domain layer
                CoinIndex coinIndex = new CoinIndex
                {
                    Price = coinIndexResponse.CurrentPrice,
                    Change = coinIndexResponse.PriceChangePercentage24H,
                    Id = indexId
                };

                return coinIndex;
            }
        }

        private string GetSuffix(CoinIndexId indexId)
        {
            switch (indexId)
            {
                case CoinIndexId.bitcoin:
                    return "bitcoin";
                case CoinIndexId.etherium:
                    return "ethereum";
                default:
                    //TODO: fix this later
                    return "bitcoin";
            }
        }
    }
}