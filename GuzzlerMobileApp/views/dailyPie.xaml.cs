using GuzzlerMobileApp.DataModel;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Uwp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            this.InitializeComponent();

            double guzzeldDevPower = 40;
    //        double guzzeldTotalPower = 140;

            string DevPower = guzzeldDevPower.ToString() + " kW on " + dateToString(Date);
            DevGuzzeled = DevName + " Guzzled: " + DevPower;



            powerPartition =(new Common.deviceGraphAnalysis()).getDailyPowerPie(Date.ToLocalTime()) ;
         //   powerPartition.Add(new piePowerItem("leon", 0.36));
          //  powerPartition.Add(new piePowerItem("rest", 0.64));

            string[] devs = new string[2] { "leon" ,"rest" };
            double[] vals = new double[2] { 0.31,0.69 };


            try
            {
                
                Series = new SeriesCollection();
                
                foreach(piePowerItem it in powerPartition)
                {
                    Series.Add(new PieSeries()
                    {
                        Values = new ChartValues<double>(new double[] { (Math.Round(it.Val,6)) })
                                       ,
                        Title = it.Dev ,
                    });
                }

                //for (int i =0; i< 2; i++)
                //{
                //    Series.Add(new PieSeries() { Values = new ChartValues<double>(new double[] { (vals[i]) })
                //    ,
                //    Title = "a"+ i});

                //}



                //  {
                //new PieSeries
                //{
                //    Values =  new ChartValues<double>( vals)

                //},
                // };
                //Series.Add(new PieSeries() { Values = Values0 });
                //Series.Add(new PieSeries() { Values = Values1 });

                //  Series = new PieSeries();
                //  Series.Values = new ChartValues<double>( vals);

                PointLabel = chartPoint =>
                  string.Format("({0})", chartPoint.Y);

                DataContext = this;
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
        public IChartValues Values0 { get; set; } = new ChartValues<int>(new int[] { 1});

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
