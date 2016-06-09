using System;
using PostSharp.Patterns.Model;

namespace WhatToFlip
{
    [NotifyPropertyChanged]
    public class StatsGuiItem : IEquatable<StatsGuiItem>
    {
        public string Name { get; set; }
        public double MinPrice { get; set; }
        public double TenPercentPrice { get; set; }
        public int AddedLastDay { get; set; }
        public double Marketcap => Math.Round(AddedLastDay * TenPercentPrice, 3);

        public bool Equals(StatsGuiItem other)
        {
            if (other == null)
                return false;

            return Name == other.Name;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            StatsGuiItem other = obj as StatsGuiItem;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
