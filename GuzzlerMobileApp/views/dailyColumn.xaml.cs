using GuzzlerMobileApp.Common;
using GuzzlerMobileApp.DataModel;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using LiveCharts;
using LiveCharts.Uwp;


namespace GuzzlerMobileApp.views
{

    public sealed partial class dailyColumn : Page
    {

        public string DevName { get; private set; }
        public List<powerDayItem> powerPerHour { get; private set; }
        public string DevGuzzeled { get; private set; }
        DateTime Date { get; set; }
        deviceGraphAnalysis analysis = new deviceGraphAnalysis();

        public dailyColumn(DateTime DateTime, string name = null)
        {
            if (name == null)
                name = "";
            DevName = name;
            if (DateTime == null)
                Date = DateTimeOffset.Now.ToLocalTime().Date;
            else
                Date = DateTime;
            DevGuzzeled = "Power consumption of " + DevName + "\non the " + deviceGraphAnalysis.dateToString(Date) + "\n NIS/Day";
            this.InitializeComponent();
            double[] DailyArray = analysis.getDailyPowerPerHour(Date.ToUniversalTime(), DevName);
            double tarrif = analysis.getElectricityTaarif("Israel", "2017");
            for (int i = 0; i < 24; i++)
            {
                DailyArray[i] *= tarrif;
                DailyArray[i] = Math.Round(DailyArray[i], 3);
            }
            SeriesCollection = new SeriesCollection();

            SeriesCollection.Add(new ColumnSeries()

            {
                Title = "",
                Values = new ChartValues<double>(DailyArray),
            });

            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24" };
            Formatter = value => value.ToString("N");
            valFormatter = new Func<double, string>(p => p.ToString() + " NIS");
            DataContext = this;

        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> valFormatter { get; set; }
        public double[] Values { get; set; }



        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new dailyLog(deviceGraphAnalysis.dateToString(Date), DevName, Date.ToUniversalTime());
            Window.Current.Activate();
        }
    }

}
