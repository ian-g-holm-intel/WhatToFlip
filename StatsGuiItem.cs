using System;
using PostSharp.Patterns.Model;

namespace WhatToFlip
{
    [NotifyPropertyChanged]
    public class StatsGuiItem : IEquatable<StatsGuiItem>
    {
        public string Name { get; set; }
        public double MinPrice { get; set; }
        public double OnePercentPrice { get; set; }
        public double TwoPercentPrice { get; set; }
        public double FivePercentPrice { get; set; }
        public int SoldLastDay { get; set; }
        public double Marketcap => Math.Round(SoldLastDay * FivePercentPrice, 3);

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
