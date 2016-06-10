using System.Collections.Generic;

namespace WhatToFlip.JsonObjects
{
    public class Bucket
    {
        public string key { get; set; }
        public int doc_count { get; set; }
    }

    public class UniqueNames
    {
        public int doc_count_error_upper_bound { get; set; }
        public int sum_other_doc_count { get; set; }
        public List<Bucket> buckets { get; set; }
    }

    public class LeagueNamesAggregations
    {
        public UniqueNames uniqueNames { get; set; }
    }

    public class LeagueNamesRequest
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
        public LeagueNamesAggregations aggregations { get; set; }
    }
}
