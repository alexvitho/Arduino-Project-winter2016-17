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

namespace GuzzlerMobileApp.views
{
    class costPerHour
    {
        public costPerHour(int day, double v)
        {
            this.Hour = day;
            this.Val = v;
        }
        public int Hour { get; set; }
        public double Val { get; set; }
    }

    public sealed partial class estimatedCost : Page
    {

        
        

        public string DevName { get; private set; }
        public List<powerDayItem> powerPerDay { get; private set; }
        public string DevGuzzeled { get; private set; }
        DateTime Date { get; set; }
        deviceGraphAnalysis analysis = new deviceGraphAnalysis();
        double[] DailyArray;
        double _Bill;

        public estimatedCost( string name = null)
        {
            if (name == null)
                name = "";
            DevName = name;
           
                Date = DateTimeOffset.Now.ToLocalTime().Date;
            
            this.InitializeComponent();
            int daysInMonth = DateTime.DaysInMonth(Date.Year, Date.Month);
            double[] sum= new double[daysInMonth] ;
            for (int i =0; i < daysInMonth; i++)
            {
                sum[i] = 0;
            }
            foreach (string dev in DataModel.existingDevsModel.existingDevs)
            {
                DailyArray = analysis.getMonthlyPowerPerDay(Date.ToUniversalTime(), dev);
                for (int j=0; j < DailyArray.Length; ++j)
                {
                    sum[j] += DailyArray[j];
                }
            }
            DailyArray = sum;

            double tarrif = analysis.getElectricityTaarif("Israel", "2017");
            
            for (int i = 0; i < DailyArray.Length; i++)
            {
                DailyArray[i] *= tarrif;
                DailyArray[i] = Math.Round(DailyArray[i], 3);
            }
            SeriesCollection = new SeriesCollection();

           
            
                SeriesCollection.Add(new ColumnSeries()

                {
                    Title = "",
                    Values = new ChartValues<double>(DailyArray)
                });

            


            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24" ,"25","26","27","28","29","30","31"};
            Formatter = value => value.ToString("N");
            valFormatter = new Func<double, string>(p => Math.Round(p,3).ToString() + " NIS");
            DataContext = this;
           

        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> valFormatter { get; set; }
        public double[] Values { get; set; }

        public string Bill
        {
            get {
                
                for (int i = 0; i < DailyArray.Length; i++)
                {
                    _Bill += DailyArray[i];
                }
                return _Bill.ToString() + " Nis"; }
            private set { }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new specialDev(DevName);
            Window.Current.Activate();
        }

       

    }
}
