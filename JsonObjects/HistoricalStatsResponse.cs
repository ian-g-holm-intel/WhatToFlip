using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhatToFlip.JsonObjects
{
    public class RangeBucket
    {
        public string key { get; set; }
        public double from { get; set; }
        public string from_as_string { get; set; }
        public double to { get; set; }
        public string to_as_string { get; set; }
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public AvgPrice avgPrice { get; set; }
        public MinPrice minPriceExalted { get; set; }
        public MinPrice minPriceChaos { get; set; }
    }

    public class DateRanges
    {
        public List<RangeBucket> buckets { get; set; }
    }

    public class HistoricalStatsBucket
    {
        [JsonProperty("key")]
        public string name { get; set; }
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public AvgPrice avgPrice { get; set; }
        public DateRanges dateRanges { get; set; }
    }

    public class HistoricalStatsUniqueNames
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<HistoricalStatsBucket> buckets { get; set; }
    }

    public class HistoricalStatsAggregations
    {
        public HistoricalStatsUniqueNames uniqueNames { get; set; }
    }

    public class HistoricalStatsResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
        public HistoricalStatsAggregations aggregations { get; set; }
    }

}
