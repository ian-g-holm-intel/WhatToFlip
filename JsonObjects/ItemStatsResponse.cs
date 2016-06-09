using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhatToFlip.JsonObjects
{

    public class ItemStatsShards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }

    public class ItemStatsHits
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<object> hits { get; set; }
    }

    public class TimeAddedBucket
    {
        public string key_as_string { get; set; }
        public object key { get; set; }
        public int doc_count { get; set; }
    }

    public class TimeAdded
    {
        public List<TimeAddedBucket> buckets { get; set; }
    }

    public class Values
    {
        [JsonProperty("1.0")]
        public double OnePercent { get; set; }
        [JsonProperty("2.0")]
        public double TwoPercent { get; set; }
        [JsonProperty("3.0")]
        public double ThreePercent { get; set; }
        [JsonProperty("5.0")]
        public double FivePercent { get; set; }
        [JsonProperty("10.0")]
        public double TenPercent { get; set; }
    }

    public class AvgPrice
    {
        public Values values { get; set; }
    }

    public class MinPrice
    {
        public double value { get; set; }
    }

    public class MinPriceExalted
    {
        public double? value { get; set; }
    }

    public class MinPriceChaos
    {
        public double? value { get; set; }
    }

    public class ItemStatsBucket
    {
        [JsonProperty("key")]
        public string name { get; set; }
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public TimeAdded timeAdded { get; set; }
        public AvgPrice avgPrice { get; set; }
        public MinPrice minPrice { get; set; }
        public MinPriceExalted minPriceExalted { get; set; }
        public MinPriceChaos minPriceChaos { get; set; }
    }

    public class UniqueNames
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<ItemStatsBucket> buckets { get; set; }
    }

    public class Aggregations
    {
        public UniqueNames uniqueNames { get; set; }
    }

    public class ItemStatsResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public ItemStatsShards _shards { get; set; }
        public ItemStatsHits hits { get; set; }
        public Aggregations aggregations { get; set; }
    }
}
