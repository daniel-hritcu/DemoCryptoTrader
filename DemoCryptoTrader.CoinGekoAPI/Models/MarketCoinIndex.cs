using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace DemoCryptoTrader.CoinGekoAPI.Models
{
    public partial class MarketCoinIndex
    {
        [J("id")] public string Id { get; set; }
        [J("symbol")] public string Symbol { get; set; }
        [J("name")] public string Name { get; set; }
        [J("image")] public Uri Image { get; set; }
        [J("current_price")] public double CurrentPrice { get; set; }
        [J("market_cap")] public long MarketCap { get; set; }
        [J("market_cap_rank")] public long MarketCapRank { get; set; }
        [J("total_volume")] public long TotalVolume { get; set; }
        [J("high_24h")] public double High24H { get; set; }
        [J("low_24h")] public double Low24H { get; set; }
        [J("price_change_24h")] public double PriceChange24H { get; set; }
        [J("price_change_percentage_24h")] public double PriceChangePercentage24H { get; set; }
        [J("market_cap_change_24h")] public double MarketCapChange24H { get; set; }
        [J("market_cap_change_percentage_24h")] public double MarketCapChangePercentage24H { get; set; }
        [J("circulating_supply")] public long CirculatingSupply { get; set; }
        [J("total_supply")] public long TotalSupply { get; set; }
        [J("ath")] public double Ath { get; set; }
        [J("ath_change_percentage")] public double AthChangePercentage { get; set; }
        [J("ath_date")] public DateTimeOffset AthDate { get; set; }
        [J("atl")] public double Atl { get; set; }
        [J("atl_change_percentage")] public double AtlChangePercentage { get; set; }
        [J("atl_date")] public DateTimeOffset AtlDate { get; set; }
        [J("roi")] public dynamic Roi { get; set; }
        [J("last_updated")] public DateTimeOffset LastUpdated { get; set; }
    }

    public partial class MarketCoinIndex
    {
        public static List<MarketCoinIndex> FromJson(string json) => JsonConvert.DeserializeObject<List<MarketCoinIndex>>(json, DemoCryptoTrader.CoinGekoAPI.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<MarketCoinIndex> self) => JsonConvert.SerializeObject(self, DemoCryptoTrader.CoinGekoAPI.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
