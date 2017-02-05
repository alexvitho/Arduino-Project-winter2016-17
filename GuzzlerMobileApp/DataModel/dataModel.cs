using System;
using System.Collections.Generic;

namespace GuzzlerMobileApp.DataModel
{
    // data structure to use in power/time graph
    public class powerTimeItem : IComparable< powerTimeItem>
    {
        public powerTimeItem(DateTime time, double v)
        {
            this.time = time;
            this.value = v;
        }
        public DateTime time { get; set; }
        public double value { get; set; }
        public class TimeFirst : IComparer<powerTimeItem>
        {
            //// Compares by time
           
            public int Compare(powerTimeItem x, powerTimeItem y)
            {
                if (x.time.CompareTo(y.time) != 0)
                {
                    return x.time.CompareTo(y.time);
                }
                return 0;
            }
        }

        public int CompareTo(powerTimeItem other)
        {
            if (this.time.CompareTo(other.time) != 0)
            {
                return this.time.CompareTo(other.time);
            }
            return 0;
        }
    }
    // data structure to use in power/day graph
    public class powerDayItem
    {

        public powerDayItem()
        {
            this.Day =0;
            this.Val = 0;
        }
        public powerDayItem(int hour, double v)
        {
            this.Day = hour;
            this.Val = v;
        }
        public int Day { get; set; }
        public double Val { get; set; }
    }
    // data structure to use in power/device graph
    public class piePowerItem
    {
        public piePowerItem(string dev, double v)
        {
            this.Dev = dev;
            this.Val = v;
        }
        public string Dev { get; set; }
        public double Val { get; set; }
    }
    // This is the Devices existing in our database.
    static public class existingDevsModel
    {
        static public List<string> existingDevs;
        static public Dictionary<string, string> nickToId;

    }
}
