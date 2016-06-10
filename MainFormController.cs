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

        public void Update()
        {
            guiInterface.InProgress = true;
            ThreadPool.QueueUserWorkItem(parameters =>
            {
                var uniques = exileToolsClient.GetItemStats();
                var exaltedPrice = exileToolsClient.GetExaltPrice();
                guiInterface.InProgress = false;
                guiInterface.InvokeGrid(() =>
                {
                    foreach (var item in uniques)
                    {
                        var newItem = new StatsGuiItem
                        {
                            Name = item.name,
                            MinPrice = minPriceFinder.GetMinPrice(item.verified.buckets.yes, exaltedPrice),
                            OnePercentPrice = Math.Round(item.avgPrice.values.OnePercent, 3),
                            TwoPercentPrice = Math.Round(item.avgPrice.values.TwoPercent, 3),
                            FivePercentPrice = Math.Round(item.avgPrice.values.FivePercent, 3),
                            SoldLastDay = item.verified.buckets.gone.count
                        };


                        guiInterface.UpdateItem(newItem);
                    }
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
        public List<ItemStatsBucket> GetItemStats()
        {
            string jsonData = "{\r\n\t\"query\": {\r\n\t\t\"bool\": {\r\n\t\t\t\"must\": [{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.league\": {\r\n\t\t\t\t\t\t\"value\": \"Prophecy\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.hasPrice\": {\r\n\t\t\t\t\t\t\"value\": \"true\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"range\": { \r\n\t\t\t\t\t\"shop.updated\":{\r\n\t\t\t\t\t\t\"gte\":\"now-1d\",\r\n\t\t\t\t\t\t\"lte\":\"now\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}],\r\n\t\t\t\"must_not\": [{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Magic\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Rare\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Currency\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Gem\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}]\r\n\t\t}\r\n\t},\r\n\t\"aggs\": {\r\n\t\t\"uniqueNames\": {\r\n\t\t\t\"terms\": {\r\n\t\t\t\t\"field\": \"info.fullName\",\r\n\t\t\t\t\"size\": 100,\r\n\t\t\t\t\"order\": {\r\n\t\t\t\t\t\"minPrice\": \"desc\"\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t\"aggs\": {\r\n\t\t\t\t\"minPrice\": {\r\n\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\"\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\t\"avgPrice\": {\r\n\t\t\t\t\t\"percentiles\": {\r\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\",\r\n\t\t\t\t\t\t\"percents\": [1,2,3,5,10]\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\t\"verified\" : {\r\n\t\t\t\t\t\"filters\" : {\r\n\t\t\t\t\t\t\"filters\" : {\r\n\t\t\t\t\t\t\t\"gone\" :   { \"term\" : { \"shop.verified\" : \"GONE\" }},\r\n\t\t\t\t\t\t\t\"yes\" : { \"term\" : { \"shop.verified\" : \"YES\" }}\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"aggs\": {\r\n\t\t\t\t\t\t\"minPriceExalted\": {\r\n\t\t\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\t\t\"field\": \"shop.price.Exalted Orb\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\"minPriceChaos\": {\r\n\t\t\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\t\t\"field\": \"shop.price.Chaos Orb\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\t},\r\n\t\"size\": 0\r\n}";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                var response = JsonConvert.DeserializeObject<ItemStatsResponse>(result);
                return response.aggregations.uniqueNames.buckets;
            }
        }

        public double GetExaltPrice()
        {
            string jsonData = "{\r\n\t\"query\": {\r\n\t\t\"bool\": {\r\n\t\t\t\"must\": [{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.league\": {\r\n\t\t\t\t\t\t\"value\": \"Prophecy\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.hasPrice\": {\r\n\t\t\t\t\t\t\"value\": \"true\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.currency\": {\r\n\t\t\t\t\t\t\"value\": \"Chaos Orb\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.verified\": {\r\n\t\t\t\t\t\t\"value\": \"YES\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"range\": { \r\n\t\t\t\t\t\"shop.updated\":{\r\n\t\t\t\t\t\t\"gte\":\"now-1h\",\r\n\t\t\t\t\t\t\"lte\":\"now\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Currency\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}]\r\n\t\t}\r\n\t},\r\n\t\"aggs\": {\r\n\t\t\"uniqueNames\": {\r\n\t\t\t\"terms\": {\r\n\t\t\t\t\"field\": \"info.fullName\",\r\n\t\t\t\t\"include\": \"Exalted Orb\"\r\n\t\t\t},\r\n\t\t\t\"aggs\": {\r\n\t\t\t\t\"minPrice\": {\r\n\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\"field\": \"shop.amount\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\t},\r\n\t\"size\": 0\r\n}";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                var response = JsonConvert.DeserializeObject<ExaltPriceResponse>(result);
                var exaltPriceBucket = response.aggregations.uniqueNames.buckets.SingleOrDefault(bucket => bucket.key == "Exalted Orb");
                return exaltPriceBucket?.minPrice.value ?? 0;
            }
        }
    }
}
