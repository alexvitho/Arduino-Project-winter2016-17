using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace GuzzlerMobileApp.views
{
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

    public sealed partial class dailyPie : Page
    {
        public string DevName { get; private set; }
        public ObservableCollection<piePowerItem> powerPartition { get; private set; }
        public string DevPower { get; private set; }
        public string DevGuzzeled { get; private set; }
        DateTime Date { get; set; }

        public dailyPie(DateTime DateTime, string name = null)
        {
            if (name == null)
                name = "";
            DevName = name;
            if (DateTime == null)
                Date = DateTimeOffset.Now.ToLocalTime().Date;
            else
                Date = DateTime;

            this.InitializeComponent();
            DevGuzzeled = DevName + " Guzzled:";

            double guzzeldDevPower = 40;
            DevPower = guzzeldDevPower.ToString() + " kW on " + dateToString(Date);
            double guzzeldTotalPower = 140;
            try
            {
                powerPartition = new ObservableCollection<piePowerItem>();
                powerPartition.Add(new piePowerItem(DevName, guzzeldDevPower / guzzeldTotalPower));
                powerPartition.Add(new piePowerItem("else", (guzzeldTotalPower - guzzeldDevPower) / guzzeldTotalPower));
                ((PieSeries)PieChart.Series[0]).ItemsSource = powerPartition;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Data);
            }

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new dayLog(dateToString(Date), DevName, Date.ToUniversalTime());
            Window.Current.Activate();
        }
        string dateToString(DateTime date)
        {
            return (date == null) ? "" : date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
        }
    }
}
