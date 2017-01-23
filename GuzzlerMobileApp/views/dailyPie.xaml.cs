using GuzzlerMobileApp.DataModel;
using LiveCharts;
using LiveCharts.Configurations;
using System;
using System.Collections.Generic;
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
        public List<piePowerItem> powerPartition { get; private set; }
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
            powerPartition = new List<piePowerItem>();
            powerPartition.Add(new piePowerItem("leon", 0.36));
            powerPartition.Add(new piePowerItem("rest", 0.64));

       

            try
            {

                Series = new SeriesCollection(null)
                  {
             
                 };


                PointLabel = chartPoint =>
                 string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);


                //powerPartition = new ObservableCollection<piePowerItem>();
                //powerPartition.Add(new piePowerItem(DevName, guzzeldDevPower / guzzeldTotalPower));
                //powerPartition.Add(new piePowerItem("else", (guzzeldTotalPower - guzzeldDevPower) / guzzeldTotalPower));
                //((PieSeries)PieChart.Series[0]).ItemsSource = powerPartition;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Data);
            }

        }
        public Func<ChartPoint, string> PointLabel { get; set; }
        public SeriesCollection Series { get; set; }

        public IChartValues Values1 { get; set; } = new ChartValues<int>(new int[] { 3 });
        public IChartValues Values2 { get; set; } = new ChartValues<int>(new int[] { 3 });
        public IChartValues Values3 { get; set; } = new ChartValues<int>(new int[] { 3 });
        public IChartValues Values4 { get; set; } = new ChartValues<int>(new int[] { 3 });
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new dailyLog(dateToString(Date), DevName, Date.ToUniversalTime());
            Window.Current.Activate();
        }

    }
}
