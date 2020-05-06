using DemoCryptoTrader.CoinGekoAPI.Models;
using DemoCryptoTrader.Domain.Models;
using DemoCryptoTrader.Domain.Services;
using DemoCryptoTrader.Domain.Exceptions;
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
        public async Task<CoinIndex> GetCoinIndex(CoinIndexId indexId)
        {
            //Get CoinIndex
            CoinIndex coinIndex = await GetCoin(GetSuffix(indexId));

            //Set coinIndexId
            coinIndex.Id = indexId;
 
            //Return coinIndex
            return coinIndex;
        }

        public async Task<CoinIndex> GetCoinPrice(string coinId)
        {
            //Get CoinIndex
            CoinIndex coinIndex = await GetCoin(coinId);

            //Return coinIndex
            return coinIndex;
        }


        //Helper methods

        private async Task<CoinIndex> GetCoin(string coinId)
        {
            //new null response
            CoinIndex coinIndex = null;

            //Api market uri
            string apiCallUri = "coins/markets?vs_currency=usd&ids=" + coinId;

            using (CoinGekoApiHttpClient client = new CoinGekoApiHttpClient())
            {
                //Get httpResponse from api
                HttpResponseMessage httpResponse = await client.GetAsync(apiCallUri);

                if (httpResponse.IsSuccessStatusCode)
                {
                    //Get json string from httpResponse
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    //Deserialize the jsonResponse into a response model
                    CoinIndexResponse coinIndexResponse = CoinIndexResponse.FromJson(jsonResponse)[0];

                    //Check if response is not broken
                    //We don't want to buy non existing or 0$ coins
                    if (coinIndexResponse.CurrentPrice == 0)
                    {
                        throw new InvalidCoinIdException(coinId);
                    }

                    //Return CoinIndex model from Domain layer
                    coinIndex = new CoinIndex
                    {
                        Price = coinIndexResponse.CurrentPrice,
                        Change = coinIndexResponse.PriceChangePercentage24H,
                        Name = coinIndexResponse.Name,
                        Id = new CoinIndexId()
                    };
                }
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
                    throw new Exception("CoinIndexId not defined.");
            }
        }
    }
}