using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToFlip.JsonObjects
{
    public class ExaltPriceShards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }

    public class ExaltPriceHits
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<object> hits { get; set; }
    }

    public class ExaltPriceBucket
    {
        public string key { get; set; }
        public int doc_count { get; set; }
        public MinPrice minPrice { get; set; }
    }

    public class ExaltPriceUniqueNames
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<ExaltPriceBucket> buckets { get; set; }
    }

    public class ExaltPriceAggregations
    {
        public ExaltPriceUniqueNames uniqueNames { get; set; }
    }

    public class ExaltPriceResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public ExaltPriceShards _shards { get; set; }
        public ExaltPriceHits hits { get; set; }
        public ExaltPriceAggregations aggregations { get; set; }
    }
}
