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
                guiInterface.InProgress = false;
                guiInterface.InvokeGrid(() =>
                {
                    foreach (var item in uniques)
                    {
                        var newItem = new StatsGuiItem
                        {
                            Name = item.name,
                            MinPrice = minPriceFinder.GetMinPrice(item, 58.0),
                            OnePercentPrice = Math.Round(item.avgPrice.values.OnePercent, 3),
                            TwoPercentPrice = Math.Round(item.avgPrice.values.TwoPercent, 3),
                            FivePercentPrice = Math.Round(item.avgPrice.values.FivePercent, 3),
                            SoldLastDay = item.count
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
        public double GetMinPrice(ItemStatsBucket item, double chaosToExaltRatio)
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
            string jsonData = "{\n\t\"query\": {\r\n\t\t\"filtered\": {\r\n\t\t\t\"query\": {\n\t\t\t\t\"bool\": {\n\t\t\t\t\t\"must\": [{\n\t\t\t\t\t\t\"term\": {\n\t\t\t\t\t\t\t\"attributes.league\": {\n\t\t\t\t\t\t\t\t\"value\": \"Prophecy\"\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t}\n\t\t\t\t\t},\n\t\t\t\t\t{\r\n\t\t\t\t\t\t\"term\": {\r\n\t\t\t\t\t\t\t\"shop.hasPrice\": {\r\n\t\t\t\t\t\t\t\t\"value\": \"true\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t\"term\": {\r\n\t\t\t\t\t\t\t\"shop.verified\": {\r\n\t\t\t\t\t\t\t\t\"value\": \"GONE\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}],\n\t\t\t\t\t\"must_not\": [{\n\t\t\t\t\t\t\"term\": {\n\t\t\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\t\t\"value\": \"Magic\"\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t}\n\t\t\t\t\t},\n\t\t\t\t\t{\n\t\t\t\t\t\t\"term\": {\n\t\t\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\t\t\"value\": \"Rare\"\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t}\n\t\t\t\t\t},\n\t\t\t\t\t{\n\t\t\t\t\t\t\"term\": {\n\t\t\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\t\t\"value\": \"Currency\"\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t}\n\t\t\t\t\t},\n\t\t\t\t\t{\n\t\t\t\t\t\t\"term\": {\n\t\t\t\t\t\t\t\"attributes.rarity\": {\n\t\t\t\t\t\t\t\t\"value\": \"Gem\"\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t}\n\t\t\t\t\t}]\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t\"filter\": {\r\n\t\t\t\t\"range\": { \r\n\t\t\t\t\t\"shop.updated\": { \r\n\t\t\t\t\t\t\"gte\": \"now-1d\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\n\t},\n\t\"aggs\": {\n\t\t\"uniqueNames\": {\n\t\t\t\"terms\": {\n\t\t\t\t\"field\": \"info.fullName\",\n\t\t\t\t\"size\": 100,\n\t\t\t\t\"order\": {\n\t\t\t\t\t\"minPrice\": \"desc\"\n\t\t\t\t}\n\t\t\t},\n\t\t\t\"aggs\": {\n\t\t\t\t\"avgPrice\": {\n\t\t\t\t\t\"percentiles\": {\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\",\n\t\t\t\t\t\t\"percents\": [1,2,3,5,10]\n\t\t\t\t\t}\n\t\t\t\t},\r\n\t\t\t\t\"minPrice\": {\r\n\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\"\r\n\t\t\t\t\t}\r\n\t\t\t\t},\n\t\t\t\t\"minPriceExalted\": {\r\n\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\"field\": \"shop.price.Exalted Orb\"\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\t\"minPriceChaos\": {\r\n\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\"field\": \"shop.price.Chaos Orb\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\n\t\t\t}\n\t\t}\n\t},\n\t\"size\": 0\n}";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                var response = JsonConvert.DeserializeObject<ItemStatsResponse>(result);
                return response.aggregations.uniqueNames.buckets;
            }
        }
    }
}
