using System;
using System.Collections.Generic;
using System.Configuration;
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
        private readonly PriceFinder priceFinder;
        private readonly AppConfigHandler appConfig;
        public MainFormController(IMainForm gui)
        {
            guiInterface = gui;
            exileToolsClient = new ExileToolsClient();
            priceFinder = new PriceFinder();
            appConfig = new AppConfigHandler();
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
                var currentLowData = exileToolsClient.GetCurrentLow(guiInterface.SelectedLeague);
                var historicalData = exileToolsClient.GetHistoricalStats(guiInterface.SelectedLeague);
                var exaltedPrice = exileToolsClient.GetExaltPrice(guiInterface.SelectedLeague);
                guiInterface.ExaltPrice = exaltedPrice;
                exaltedPrice = exaltedPrice == 0 ? 60 : exaltedPrice;
                guiInterface.InvokeGrid(() =>
                {
                    foreach (var item in currentLowData)
                    {
                        var itemData = historicalData.SingleOrDefault(historicalItem => historicalItem.name == item.name);
                        if (itemData == null) continue;
                        var newItem = new StatsGuiItem
                        {
                            Name = item.name,
                            CurrentLow = priceFinder.GetMinPrice(item.minPriceChaos, item.minPriceExalted, exaltedPrice),
                            SoldLast24h = itemData.dateRanges.buckets.Last().count,
                            Note = appConfig.GetValue(item.name)
                        };
                        newItem.Low24h = Math.Min(newItem.CurrentLow, priceFinder.GetMinPrice(itemData.dateRanges.buckets.Last().minPriceChaos, itemData.dateRanges.buckets.Last().minPriceExalted, exaltedPrice));
                        newItem.OneDayAgoAvg = itemData.dateRanges.buckets[2].avgPrice.values.TenPercent;
                        newItem.TwoDayAgoAvg = itemData.dateRanges.buckets[1].avgPrice.values.TenPercent;
                        newItem.ThreeDayAgoAvg = itemData.dateRanges.buckets[0].avgPrice.values.TenPercent;
                        guiInterface.UpdateItem(newItem);
                    }
                    if (resort)
                        guiInterface.SortByMarketValue();
                    guiInterface.ClearGridSelection();
                    guiInterface.InProgress = false;
                });
            });
        }

        public void CellValueChanged(string Key, string Value)
        {
            ThreadPool.QueueUserWorkItem(parameters =>
            {
                appConfig.SetValue(Key, Value);
            });
        }
    }

    public class PriceFinder
    {
        public double GetMinPrice(MinPrice minPriceChaos, MinPrice minPriceExalted, double chaosToExaltRatio)
        {
            if(minPriceChaos.value == null && minPriceExalted.value == null)
            {
                return 0.0;
            }
            if (minPriceChaos.value == null)
            {
                return Math.Round((double)(minPriceExalted.value * chaosToExaltRatio), 3);
            }
            if (minPriceExalted.value == null)
            {
                return Math.Round(minPriceChaos.value.Value, 3);
            }
            return Math.Round(Math.Min(minPriceChaos.value.Value, minPriceExalted.value.Value*chaosToExaltRatio), 3);
        }
    }

    public class AppConfigHandler
    {
        private readonly Configuration config;
        public AppConfigHandler()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public void SetValue(string Key, string Value)
        {
            if (config.AppSettings.Settings[Key] == null)
                config.AppSettings.Settings.Add(Key, Value);
            else
                config.AppSettings.Settings[Key].Value = Value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSetting");
        }

        public string GetValue(string Key)
        {
            return config.AppSettings.Settings[Key] == null ? "" : config.AppSettings.Settings[Key].Value;
        }
    }

    public class ExileToolsClient
    {
        public List<CurrentLowBucket> GetCurrentLow(string leagueName)
        {
            try
            {
                string jsonData = "{\r\n\t\"query\": {\r\n\t\t\"bool\": {\r\n\t\t\t\"must\": [{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.league\": {\r\n\t\t\t\t\t\t\"value\": \"" + leagueName + "\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.hasPrice\": {\r\n\t\t\t\t\t\t\"value\": \"true\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"range\": {\r\n\t\t\t\t\t\"shop.chaosEquiv\": {\r\n\t\t\t\t\t\t\"lte\": 8000\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.verified\": {\r\n\t\t\t\t\t\t\"value\": \"YES\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}],\r\n\t\t\t\"must_not\": [{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Magic\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Rare\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Currency\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Gem\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}]\r\n\t\t}\r\n\t},\r\n\t\"aggs\": {\r\n\t\t\"uniqueNames\": {\r\n\t\t\t\"terms\": {\r\n\t\t\t\t\"field\": \"info.fullName\",\r\n\t\t\t\t\"size\": 100,\r\n\t\t\t\t\"order\": {\r\n\t\t\t\t\t\"avgPrice.10\": \"desc\"\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t\"aggs\": {\r\n\t\t\t\t\"avgPrice\": {\r\n\t\t\t\t\t\"percentiles\": {\r\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\",\r\n\t\t\t\t\t\t\"percents\": [10]\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\t\"minPriceExalted\": {\r\n\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\"field\": \"shop.price.Exalted Orb\"\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\t\"minPriceChaos\": {\r\n\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\"field\": \"shop.price.Chaos Orb\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\t},\r\n\t\"size\": 0\r\n}";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                    var response = JsonConvert.DeserializeObject<CurrentLowResponse>(result);
                    return response.aggregations.uniqueNames.buckets;
                }
            }

            catch(Exception ex)
            {
                return new List<CurrentLowBucket>();
            }
        }

        public List<HistoricalStatsBucket> GetHistoricalStats(string leagueName)
        {
            try
            {
                string jsonData = "{\r\n\t\"query\": {\r\n\t\t\"bool\": {\r\n\t\t\t\"must\": [{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.league\": {\r\n\t\t\t\t\t\t\"value\": \"" + leagueName + "\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.hasPrice\": {\r\n\t\t\t\t\t\t\"value\": \"true\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"range\": {\r\n\t\t\t\t\t\"shop.chaosEquiv\": {\r\n\t\t\t\t\t\t\"lte\": 8000\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"shop.verified\": {\r\n\t\t\t\t\t\t\"value\": \"GONE\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}],\r\n\t\t\t\"must_not\": [{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Magic\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Rare\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Currency\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\"term\": {\r\n\t\t\t\t\t\"attributes.rarity\": {\r\n\t\t\t\t\t\t\"value\": \"Gem\"\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}]\r\n\t\t}\r\n\t},\r\n\t\"aggs\": {\r\n\t\t\"uniqueNames\": {\r\n\t\t\t\"terms\": {\r\n\t\t\t\t\"field\": \"info.fullName\",\r\n\t\t\t\t\"size\": 100,\r\n\t\t\t\t\"order\": {\r\n\t\t\t\t\t\"avgPrice.10\": \"desc\"\r\n\t\t\t\t}\r\n\t\t\t},\r\n\t\t\t\"aggs\": {\r\n\t\t\t\t\"avgPrice\": {\r\n\t\t\t\t\t\"percentiles\": {\r\n\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\",\r\n\t\t\t\t\t\t\"percents\": [10]\r\n\t\t\t\t\t}\r\n\t\t\t\t},\r\n\t\t\t\t\"dateRanges\": {\r\n\t\t\t\t\t\"date_range\": {\r\n\t\t\t\t\t\t\"field\": \"shop.modified\",\r\n\t\t\t\t\t\t\"format\": \"yyyy-MM-dd HH:mm:ss\",\r\n\t\t\t\t\t\t\"ranges\": [{\r\n\t\t\t\t\t\t\t\"from\": \"now-1d\"\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\"from\": \"now-2d\",\r\n\t\t\t\t\t\t\t\"to\": \"now-1d\"\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\"from\": \"now-3d\",\r\n\t\t\t\t\t\t\t\"to\": \"now-2d\"\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\"from\": \"now-4d\",\r\n\t\t\t\t\t\t\t\"to\": \"now-3d\"\r\n\t\t\t\t\t\t}]\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"aggs\": {\r\n\t\t\t\t\t\t\"minPriceExalted\": {\r\n\t\t\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\t\t\"field\": \"shop.price.Exalted Orb\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\"minPriceChaos\": {\r\n\t\t\t\t\t\t\t\"min\": {\r\n\t\t\t\t\t\t\t\t\"field\": \"shop.price.Chaos Orb\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\"avgPrice\": {\r\n\t\t\t\t\t\t\t\"percentiles\": {\r\n\t\t\t\t\t\t\t\t\"field\": \"shop.chaosEquiv\",\r\n\t\t\t\t\t\t\t\t\"percents\": [10]\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t}\r\n\t},\r\n\t\"size\": 0\r\n}";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.Authorization] = "DEVELOPMENT-Indexer";
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var result = client.UploadString(@"http://api.exiletools.com/index/_search?pretty", "POST", jsonData);
                    var response = JsonConvert.DeserializeObject<HistoricalStatsResponse>(result);
                    return response.aggregations.uniqueNames.buckets;
                }
            }

            catch (Exception ex)
            {
                return new List<HistoricalStatsBucket>();
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
                    var response = JsonConvert.DeserializeObject<LeagueNamesResponse>(result);
                    return (from LeagueNamesBucket bucket in response.aggregations.uniqueNames.buckets select bucket.key).ToArray();
                }
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
