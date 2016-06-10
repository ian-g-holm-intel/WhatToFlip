using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using WhatToFlip.JsonObjects;

namespace WhatToFlip
{
    public class MainFormController
    {
        private readonly IMainForm guiInterface;
        private readonly ExileToolsClient exileToolsClient;
        private readonly MinPriceFinder minPriceFinder;
        public MainFormController(IMainForm gui)
        {
            guiInterface = gui;
            exileToolsClient = new ExileToolsClient();
            minPriceFinder = new MinPriceFinder();
        }

        public void FetchLeagueNames()
        {
            guiInterface.InProgress = true;
            ThreadPool.QueueUserWorkItem(parameters =>
            {
                guiInterface.SetLeagueNames(exileToolsClient.GetLeagueNames());
            });
        }

        public void Update(bool resort)
        {
            guiInterface.InProgress = true;
            ThreadPool.QueueUserWorkItem(parameters =>
            {
                var uniques = exileToolsClient.GetItemStats(guiInterface.SelectedLeague);
                var exaltedPrice = exileToolsClient.GetExaltPrice(guiInterface.SelectedLeague);
                guiInterface.ExaltPrice = exaltedPrice;
                guiInterface.InProgress = false;
                guiInterface.InvokeGrid(() =>
                {
                    foreach (var item in uniques)
                    {
                        var newItem = new StatsGuiItem
                        {
                            Name = item.name,
                            MinPrice = minPriceFinder.GetMinPrice(item.verified.buckets.yes, exaltedPrice == 0 ? 60 : exaltedPrice),
                            OnePercentPrice = Math.Round(item.avgPrice.values.OnePercent, 3),
                            TwoPercentPrice = Math.Round(item.avgPrice.values.TwoPercent, 3),
                            FivePercentPrice = Math.Round(item.avgPrice.values.FivePercent, 3),
                            SoldLastDay = item.verified.buckets.gone.count
                        };
                        guiInterface.UpdateItem(newItem);
                    }
                    if(resort)
                        guiInterface.SortByMarketValue();
                });
            });
        }
    }

    public class MinPriceFinder
    {
        public double GetMinPrice(VerifiedYes item, double chaosToExaltRatio)
        {
            if(item.minPriceChaos.value == null && item.minPriceExalted.value == null)
            {
                return 0.0;
            }
            if (item.minPriceChaos.value == null)
            {
                return Math.Round((double)(item.minPriceExalted.value * chaosToExaltRatio), 3);
            }
            if (item.minPriceExalted.value == null)
            {
                return Math.Round(item.minPriceChaos.value.Value, 3);
            }
            return Math.Round(Math.Min(item.minPriceChaos.value.Value, item.minPriceExalted.value.Value*chaosToExaltRatio), 3);
        }
    }

    public class ExileToolsClient
    {
        public List<ItemStatsBucket> GetItemStats(string leagueName)
        {
            try
            {
                string jsonData = "{\"query\": {\"bool\": {\"must\": [{\"term\": {\"attributes.league\": {\"value\": \"Prophecy\"}}},{\"term\": {\"shop.hasPrice\": {\"value\": \"true\"}}},{\"range\": { \"shop.updated\":{\"gte\":\"now-1d\",\"lte\":\"now\"}}},{\"range\": { \"shop.chaosEquiv\":{\"lte\":5000}}}],\"must_not\": [{\"term\": {\"attributes.rarity\": {\"value\": \"Magic\"}}},{\"term\": {\"attributes.rarity\": {\"value\": \"Rare\"}}},{\"term\": {\"attributes.rarity\": {\"value\": \"Currency\"}}},{\"term\": {\"attributes.rarity\": {\"value\": \"Gem\"}}}]}},\"aggs\": {\"uniqueNames\": {\"terms\": {\"field\": \"info.fullName\",\"size\": 100,\"order\": {\"minPrice\": \"desc\"}},\"aggs\": {\"minPrice\": {\"min\": {\"field\": \"shop.chaosEquiv\"}},\"avgPrice\": {\"percentiles\": {\"field\": \"shop.chaosEquiv\",\"percents\": [1,2,3,5,10]}},\"verified\" : {\"filters\" : {\"filters\" : {\"gone\" :   { \"term\" : { \"shop.verified\" : \"GONE\" }},\"yes\" : { \"term\" : { \"shop.verified\" : \"YES\" }}}},\"aggs\": {\"minPriceExalted\": {\"min\": {\"field\": \"shop.price.Exalted Orb\"}},\"minPriceChaos\": {\"min\": {\"field\": \"shop.price.Chaos Orb\"}}}}}}},\"size\": 0}";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                    var response = JsonConvert.DeserializeObject<ItemStatsResponse>(result);
                    return response.aggregations.uniqueNames.buckets;
                }
            }

            catch
            {
                return new List<ItemStatsBucket>();
            }
        }

        public double GetExaltPrice(string leagueName)
        {
            try
            {
                string jsonData = "{\"query\": {\"bool\": {\"must\": [{\"term\": {\"attributes.league\": {\"value\": \"" + leagueName + "\"}}},{\"term\": {\"shop.hasPrice\": {\"value\": \"true\"}}},{\"term\": {\"shop.currency\": {\"value\": \"Chaos Orb\"}}},{\"range\": {\"shop.amount\":{\"gte\":40}}},{\"term\": {\"shop.verified\": {\"value\": \"YES\"}}},{\"range\": { \"shop.updated\":{\"gte\":\"now-1h\",\"lte\":\"now\"}}},{\"term\": {\"attributes.rarity\": {\"value\": \"Currency\"}}}]}},\"aggs\": {\"uniqueNames\": {\"terms\": {\"field\": \"info.fullName\",\"include\": \"Exalted Orb\"},\"aggs\": {\"minPrice\": {\"min\": {\"field\": \"shop.amount\"}}}}},\"size\": 0}";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                    var response = JsonConvert.DeserializeObject<ExaltPriceResponse>(result);
                    var exaltPriceBucket =
                        response.aggregations.uniqueNames.buckets.SingleOrDefault(bucket => bucket.key == "Exalted Orb");
                    return exaltPriceBucket?.minPrice.value ?? 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public string[] GetLeagueNames()
        {
            try
            {
                string jsonData = "{\"query\":{\"match_all\":{}},\"aggs\":{\"uniqueNames\":{\"terms\":{\"field\":\"attributes.league\",\"exclude\":\"false\"}}},\"size\":0}";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                    var response = JsonConvert.DeserializeObject<LeagueNamesRequest>(result);
                    return (from Bucket bucket in response.aggregations.uniqueNames.buckets select bucket.key).ToArray();
                }
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
