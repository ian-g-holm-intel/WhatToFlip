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
                string jsonData = "{\n\t\"query\": {\n\t\t\"bool\": {\n\t\t\t\"must\": [{\n\t\t\t\t\"term\": {\n\t\t\t\t\t\"attributes.league\": {\n\t\t\t\t\t\t\"value\": \"Prophecy\"\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"term\": {\n\t\t\t\t\t\"shop.hasPrice\": {\n\t\t\t\t\t\t\"value\": \"true\"\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"range\": {\n\t\t\t\t\t\"shop.updated\": {\n\t\t\t\t\t\t\"gte\": \"now-1d\",\n\t\t\t\t\t\t\"lte\": \"now\"\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"range\": {\n\t\t\t\t\t\"shop.chaosEquiv\": {\n\t\t\t\t\t\t\"lte\": 5000\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}],\n\t\t\t\"must_not\": [{\n\t\t\t\t\"term\": {\n\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\"value\": \"Magic\"\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"term\": {\n\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\"value\": \"Rare\"\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"term\": {\n\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\"value\": \"Currency\"\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"term\": {\n\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\"value\": \"Gem\"\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}]\n\t\t}\n\t},\n\t\"aggs\": {\n\t\t\"uniqueNames\": {\n\t\t\t\"terms\": {\n\t\t\t\t\"field\": \"info.fullName\",\n\t\t\t\t\"size\": 100,\n\t\t\t\t\"order\": {\n\t\t\t\t\t\"avgPrice.5\": \"desc\"\n\t\t\t\t}\n\t\t\t},\n\t\t\t\"aggs\": {\n\t\t\t\t\"minPrice\": {\n\t\t\t\t\t\"min\": {\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\"\n\t\t\t\t\t}\n\t\t\t\t},\n\t\t\t\t\"avgPrice\": {\n\t\t\t\t\t\"percentiles\": {\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\",\n\t\t\t\t\t\t\"percents\": [1,\n\t\t\t\t\t\t2,\n\t\t\t\t\t\t3,\n\t\t\t\t\t\t5,\n\t\t\t\t\t\t10]\n\t\t\t\t\t}\n\t\t\t\t},\n\t\t\t\t\"verified\": {\n\t\t\t\t\t\"filters\": {\n\t\t\t\t\t\t\"filters\": {\n\t\t\t\t\t\t\t\"gone\": {\n\t\t\t\t\t\t\t\t\"term\": {\n\t\t\t\t\t\t\t\t\t\"shop.verified\": \"GONE\"\n\t\t\t\t\t\t\t\t}\n\t\t\t\t\t\t\t},\n\t\t\t\t\t\t\t\"yes\": {\n\t\t\t\t\t\t\t\t\"term\": {\n\t\t\t\t\t\t\t\t\t\"shop.verified\": \"YES\"\n\t\t\t\t\t\t\t\t}\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t}\n\t\t\t\t\t},\n\t\t\t\t\t\"aggs\": {\n\t\t\t\t\t\t\"minPriceExalted\": {\n\t\t\t\t\t\t\t\"min\": {\n\t\t\t\t\t\t\t\t\"field\": \"shop.price.Exalted Orb\"\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t},\n\t\t\t\t\t\t\"minPriceChaos\": {\n\t\t\t\t\t\t\t\"min\": {\n\t\t\t\t\t\t\t\t\"field\": \"shop.price.Chaos Orb\"\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t}\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}\n\t\t}\n\t},\n\t\"size\": 0\n}";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                    var response = JsonConvert.DeserializeObject<ItemStatsResponse>(result);
                    return response.aggregations.uniqueNames.buckets;
                }
            }

            catch(Exception ex)
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
