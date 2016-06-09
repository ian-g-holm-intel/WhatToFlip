using System.Collections.Generic;

namespace WhatToFlip.JsonObjects
{
    public class SearchStatsShards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }

    public class Source
    {
        public int itemsUnchanged { get; set; }
        public int totalStashes { get; set; }
        public string change_id { get; set; }
        public string runTime { get; set; }
        public string uuid { get; set; }
        public double secondsToComplete { get; set; }
        public double totalTransferKB { get; set; }
        public int itemsModified { get; set; }
        public double stashesPerSecond { get; set; }
        public int itemsGone { get; set; }
        public int itemsAdded { get; set; }
        public int totalItems { get; set; }
        public double totalUncompressedTransferKB { get; set; }
        public double itemsPerSecond { get; set; }
        public string next_change_id { get; set; }
    }

    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public object _score { get; set; }
        public Source _source { get; set; }
        public List<long> sort { get; set; }
    }

    public class SearchStatsHits
    {
        public int total { get; set; }
        public object max_score { get; set; }
        public List<Hit> hits { get; set; }
    }

    public class SearchStatsResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public SearchStatsShards _shards { get; set; }
        public SearchStatsHits hits { get; set; }
    }
}
