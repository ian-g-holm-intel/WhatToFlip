using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhatToFlip.JsonObjects
{
    public class UniqueItemsShards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }

    public class UniqueItemsHits
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<object> hits { get; set; }
    }

    public class MinPrice
    {
        public double value { get; set; }
    }

    public class Values
    {
        [JsonProperty("1.0")]
        public double OnePercent { get; set; }
        [JsonProperty("10.0")]
        public double TenPercent { get; set; }
        [JsonProperty("20.0")]
        public double TwentyPercent { get; set; }
        [JsonProperty("30.0")]
        public double ThirtyPercent { get; set; }
        [JsonProperty("50.0")]
        public double FiftyPercent { get; set; }
    }

    public class AvgPrice
    {
        public Values values { get; set; }
    }

    public class HistogramBucket
    {
        [JsonProperty("key_as_string")]
        public DateTime dateTime { get; set; }
        public object key { get; set; }
        public int doc_count { get; set; }
    }

    public class TimeAdded
    {
        public List<HistogramBucket> buckets { get; set; }
    }

    public class ItemStatsBucket
    {
        [JsonProperty("key")]
        public string name { get; set; }
        [JsonProperty("doc_count")]
        public int count { get; set; }
        [JsonProperty("minPrice")]
        public MinPrice minPrice { get; set; }
        [JsonProperty("avgPrice")]
        public AvgPrice avgPrice { get; set; }
        [JsonProperty("timeAdded")]
        public TimeAdded timeAdded { get; set; }
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

    public class UniqueItemsResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public UniqueItemsShards _shards { get; set; }
        public UniqueItemsHits hits { get; set; }
        public Aggregations aggregations { get; set; }
    }
}
