using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToFlip.JsonObjects
{
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
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
        public ExaltPriceAggregations aggregations { get; set; }
    }
}
