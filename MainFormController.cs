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
        public MainFormController(IMainForm gui)
        {
            guiInterface = gui;
            exileToolsClient = new ExileToolsClient();
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
                            MinPrice = Math.Round(item.minPrice.value, 3),
                            TenPercentPrice = Math.Round(item.avgPrice.values.TenPercent, 3),
                            AddedLastDay = item.timeAdded.buckets.Last().doc_count
                        };
                        guiInterface.UpdateItem(newItem);
                    }
                    guiInterface.SortByMarketValue();
                });
            });
        }
    }

    public class ExileToolsClient
    {
        public string GetLatestChangeId()
        {
            string jsonData = "{\"query\":{\"match\":{\"_type\":\"run\"}},\"sort\":[{\"runTime\":{\"order\":\"desc\"}}],\"size\":1}";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(@"http://api.exiletools.com/stats/_search", "POST", jsonData);
                var response = JsonConvert.DeserializeObject<SearchStatsResponse>(result);
                return response.hits.hits[0]._source.next_change_id;
            }
        }

        public List<ItemStatsBucket> GetItemStats()
        {
            string jsonData = "{\"query\":{\"bool\":{\"must\":[{\"term\":{\"attributes.league\":{\"value\":\"Prophecy\"}}},{\"term\":{\"shop.hasPrice\":{\"value\":\"true\"}}}],\"must_not\":[{\"term\":{\"attributes.rarity\":{\"value\":\"Magic\"}}},{\"term\":{\"attributes.rarity\":{\"value\":\"Rare\"}}},{\"term\":{\"attributes.rarity\":{\"value\":\"Currency\"}}},{\"term\":{\"attributes.rarity\":{\"value\":\"Gem\"}}}]}},\"aggs\":{\"uniqueNames\":{\"terms\":{\"field\":\"info.fullName\",\"size\":100,\"order\":{\"minPrice\":\"desc\"}},\"aggs\":{\"avgPrice\":{\"percentiles\":{\"field\":\"shop.chaosEquiv\",\"percents\":[1,10,20,30,50]}},\"minPrice\":{\"min\":{\"field\":\"shop.chaosEquiv\"}},\"timeAdded\":{\"date_histogram\":{\"field\":\"shop.added\",\"interval\":\"1d\",\"time_zone\":\"-08:00\"}}}}},\"size\":0}";
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                var response = JsonConvert.DeserializeObject<ItemStatsResponse>(result);
                return response.aggregations.uniqueNames.buckets;
            }
        }

        public List<ItemStatsBucket> GetMinPrices()
        {
            string jsonData = "{\"query\":{\"bool\":{\"must\":[{\"term\":{\"attributes.league\":{\"value\":\"Prophecy\"}}},{\"term\":{\"shop.hasPrice\":{\"value\":\"true\"}}}],\"must_not\":[{\"term\":{\"attributes.rarity\":{\"value\":\"Magic\"}}},{\"term\":{\"attributes.rarity\":{\"value\":\"Rare\"}}},{\"term\":{\"attributes.rarity\":{\"value\":\"Currency\"}}},{\"term\":{\"attributes.rarity\":{\"value\":\"Gem\"}}}]}},\"aggs\":{\"uniqueNames\":{\"terms\":{\"field\":\"info.fullName\",\"size\":100,\"order\":{\"minPrice\":\"desc\"}},\"aggs\":{\"avgPrice\":{\"percentiles\":{\"field\":\"shop.chaosEquiv\",\"percents\":[1,10,20,30,50]}},\"minPrice\":{\"min\":{\"field\":\"shop.chaosEquiv\"}},\"timeAdded\":{\"date_histogram\":{\"field\":\"shop.added\",\"interval\":\"1d\",\"time_zone\":\"-08:00\"}}}}},\"size\":0}";

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
