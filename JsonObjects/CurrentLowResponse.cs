using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WhatToFlip.JsonObjects
{
    public class CurrentLowBucket
    {
        [JsonProperty("key")]
        public string name { get; set; }
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public AvgPrice avgPrice { get; set; }
        public MinPrice minPriceExalted { get; set; }
        public MinPrice minPriceChaos { get; set; }
    }

    public class CurrentLowUniqueNames
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<CurrentLowBucket> buckets { get; set; }
    }

    public class CurrentLowAggregations
    {
        public CurrentLowUniqueNames uniqueNames { get; set; }
    }

    public class CurrentLowResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
        public CurrentLowAggregations aggregations { get; set; }
    }
}
