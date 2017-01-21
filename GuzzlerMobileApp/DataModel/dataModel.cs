using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzzlerMobileApp.DataModel
{
    // data structure to use in power/time graph
    public class powerTimeItem
    {
        public powerTimeItem(DateTime time, double v)
        {
            this.time = time;
            this.value = v;
        }
        public DateTime time { get; set; }
        public double value { get; set; }
    }
    // data structure to use in power/day graph
    public class powerItem
    {
        public powerItem(int day, double v)
        {
            this.Day = day;
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
        static public  List<string> existingDevs;
        static public Dictionary<string, string> nickToId;

    }
}
