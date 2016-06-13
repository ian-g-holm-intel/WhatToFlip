using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WhatToFlip.Annotations;

namespace WhatToFlip
{
    public class StatsGuiItem : IEquatable<StatsGuiItem>, INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public double currentLow;

        public double CurrentLow
        {
            get
            {
                return currentLow;
            }
            set
            {
                currentLow = value;
                OnPropertyChanged();
            }
        }

        private double low24h;

        public double Low24h
        {
            get
            {
                return low24h;
            }
            set
            {
                low24h = value;
                OnPropertyChanged();
            }
        }

        private int soldLast24h;

        public int SoldLast24h
        {
            get
            {
                return soldLast24h;
            }
            set
            {
                soldLast24h = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Marketcap));
            }
        }

        public double Marketcap => Math.Round(SoldLast24h * OneDayAgoAvg, 3);

        private double oneDayAgoAvg;
        public double OneDayAgoAvg
        {
            get
            {
                return oneDayAgoAvg;
            }
            set
            {
                oneDayAgoAvg = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Marketcap));
            }
        }

        private double twoDayAgoAvg;

        public double TwoDayAgoAvg
        {
            get
            {
                return twoDayAgoAvg;
            }
            set
            {
                twoDayAgoAvg = value;
                OnPropertyChanged();
            }
        }

        private double threeDayAgoAvg;

        public double ThreeDayAgoAvg
        {
            get
            {
                return threeDayAgoAvg;
            }
            set
            {
                threeDayAgoAvg = value;
                OnPropertyChanged();
            }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
