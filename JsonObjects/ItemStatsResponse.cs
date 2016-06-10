using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhatToFlip.JsonObjects
{
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

    public class VerifiedGone
    {
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public MinPriceExalted minPriceExalted { get; set; }
        public MinPriceChaos minPriceChaos { get; set; }
    }

    public class MinPriceExalted
    {
        public double? value { get; set; }
    }

    public class MinPriceChaos
    {
        public double? value { get; set; }
    }

    public class VerifiedYes
    {
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public MinPriceExalted minPriceExalted { get; set; }
        public MinPriceChaos minPriceChaos { get; set; }
    }

    public class VerifiedBuckets
    {
        public VerifiedGone gone { get; set; }
        public VerifiedYes yes { get; set; }
    }

    public class Verified
    {
        public VerifiedBuckets buckets { get; set; }
    }

    public class ItemStatsBucket
    {
        [JsonProperty("key")]
        public string name { get; set; }
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public AvgPrice avgPrice { get; set; }
        public MinPrice minPrice { get; set; }
        public Verified verified { get; set; }
    }

    public class ItemStatsUniqueNames
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<ItemStatsBucket> buckets { get; set; }
    }

    public class ItemStatsAggregations
    {
        public ItemStatsUniqueNames uniqueNames { get; set; }
    }

    public class ItemStatsResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
        public ItemStatsAggregations aggregations { get; set; }
    }
}
