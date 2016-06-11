using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhatToFlip.JsonObjects
{
    public class Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }

    public class Hits
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<object> hits { get; set; }
    }

    public class AvgPrice
    {
        public Values values { get; set; }
    }

    public class Values
    {
        [JsonProperty("10.0")]
        public double TenPercent { get; set; }
    }

    public class MinPrice
    {
        public double? value { get; set; }
    }

    public class Verified
    {
        [JsonProperty("doc_count")]
        public int count { get; set; }
        public AvgPrice avgPrice { get; set; }
        public MinPrice minPriceExalted { get; set; }
        public MinPrice minPriceChaos { get; set; }
    }
}
