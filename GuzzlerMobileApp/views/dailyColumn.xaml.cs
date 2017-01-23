using GuzzlerMobileApp.Common;
using GuzzlerMobileApp.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LiveCharts;
using LiveCharts.Uwp;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuzzlerMobileApp.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            this.InitializeComponent();
            double[] DailyArray =analysis.getDailyPowerPerHour(Date.ToUniversalTime(), DevName);
            double tarrif = analysis.getElectricityTaarif("Israel", "2017");
            for (int i = 0; i < 24; i++)
            {
                DailyArray[i] *= tarrif;
                DailyArray[i] = Math.Round(DailyArray[i],3);
            }
            SeriesCollection = new SeriesCollection();
           
                SeriesCollection.Add(new ColumnSeries()

                {
                    Title = "Nis",
                    Values = new ChartValues<double>(DailyArray),
                //    LabelPoint= new Func<ChartPoint, string>(p => p.Y.ToString()+" NIS")
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
