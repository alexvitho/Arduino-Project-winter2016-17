using GuzzlerMobileApp.DataModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using static GuzzlerMobileApp.Common.deviceGraphAnalysis;

namespace GuzzlerMobileApp.views
{


    public sealed partial class dailyPie : Page
    {
        public string DevName { get; private set; }
        public ObservableCollection<piePowerItem> powerPartition { get; private set; }
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

            double guzzeldDevPower = 40;
            double guzzeldTotalPower = 140;

            string DevPower = guzzeldDevPower.ToString() + " kW on " + dateToString(Date);
            DevGuzzeled = DevName + " Guzzled: " + DevPower;
            
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
            Window.Current.Content = new dailyLog(dateToString(Date), DevName, Date.ToUniversalTime());
            Window.Current.Activate();
        }

    }
}
