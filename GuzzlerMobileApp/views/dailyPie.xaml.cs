using GuzzlerMobileApp.DataModel;
using LiveCharts;
using LiveCharts.Uwp;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            double guzzeldDevPower = 0;
            double totalPower = 0;
            this.InitializeComponent();
            powerPartition = (new Common.deviceGraphAnalysis()).getDailyPowerPie(Date.ToLocalTime());
            foreach (piePowerItem it in powerPartition)
            {
                totalPower += it.Val;
                if (it.Dev.Equals(DevName))
                    guzzeldDevPower = Math.Round(it.Val, 6);
            }
            totalPower = Math.Round(totalPower, 6);
            string DevPower = "On " + dateToString(Date) + "\n" + DevName + " guzzled: " + guzzeldDevPower + " kW";
            DevGuzzeled = DevPower + "\nTotal guzzled: " + totalPower + " kW";

            try
            {

                Series = new SeriesCollection();

                foreach (piePowerItem it in powerPartition)
                {
                    Series.Add(new PieSeries()
                    {
                        Values = new ChartValues<double>(new double[] { (Math.Round(it.Val, 6)) })
                                       ,
                        Title = it.Dev,
                        LabelPoint = new Func<ChartPoint, string>(chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation)
                       )

                    });
                }
                DataContext = this;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Data);
            }

        }
        public Func<ChartPoint, string> PointLabel { get; set; }
        public SeriesCollection Series { get; set; }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new dailyLog(dateToString(Date), DevName, Date.ToUniversalTime());
            Window.Current.Activate();
        }

    }
}
