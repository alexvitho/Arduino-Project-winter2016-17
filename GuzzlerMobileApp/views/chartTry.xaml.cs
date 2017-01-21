using GuzzlerMobileApp.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using static GuzzlerMobileApp.Common.deviceGraphAnalysis;

namespace GuzzlerMobileApp.views
{
    public class Records
    {
        public string Name
        { get; set; }
        public int Amount
        { get; set; }
    }

    //public class dataItem1
    //{

    //    public dataItem1(int day, double v)
    //    {
    //        this.Day = day;
    //        this.Val = v;
    //    }
    //    public int Day { get; set; }
    //    public double Val { get; set; }
    //}
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class chartTry : Page, INotifyPropertyChanged
    {
        public string intYVal { get; set; }
        public string maxYVal { get; set; }
        public string minYVal { get; set; }
        public string intXVal { get; set; }
        public string maxXVal { get; set; }
        public string minXVal { get; set; }
        private List<powerItem> data;
        public List<powerItem> Data
        {
            get { return data; }
            set
            {
                if (data != value)
                    data = value;
                NotifyPropertyChanged("Data");
            }
        }
        public ObservableCollection<powerItem> Data1 { get; private set; }
        public ObservableCollection<powerItem> Data2 { get; private set; }
        public chartTry()
        {
            intYVal = 1.ToString();
            maxYVal = 300.ToString();
            minYVal = 0.ToString();
            intXVal = 30.ToString();
            maxXVal = 24.ToString();
            minXVal = 0.ToString();
            this.InitializeComponent();
            LoadChartContents();
            try
            {
                data = new List<powerItem>();
                Data1 = new ObservableCollection<powerItem>();
                for (int i = 0; i < 30; i++)
                {
                    data.Add(new powerItem(i, i * 10));
                    Data1.Add(new powerItem(i, i * 10));
                }
                Data2 = new ObservableCollection<powerItem>();

                Data2.Add(new powerItem(1, 0.64));
                Data2.Add(new powerItem(2, 0.36));

                ((LineSeries)LineChart.Series[0]).ItemsSource = Data1;
                ((LineSeries)LineChart.Series[0]).DependentRangeAxis = new LinearAxis()
                {
                    Maximum = 350,
                    Minimum = 10,
                    Orientation = AxisOrientation.Y,
                    Interval = 40,
                    ShowGridLines = true,
                    
                };
                
                ((LineSeries)LineChart.Series[0]).IndependentAxis = new LinearAxis()
                {
                    Maximum = 35,
                    Minimum = 1,
                    Orientation = AxisOrientation.X,
                    Interval = 3,
                    ShowGridLines = true,

                };
                ((PieSeries)PieChart.Series[0]).ItemsSource = Data2;
                //((PieSeries)PieChart.Series[0]).r

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Data);
            }

        }


        #region INotifyPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion



        public void LoadChartContents()
        {
            Random rand = new Random();
            List<Records> records = new List<Records>();
            records.Add(new Records()
            {
                Name = "Suresh",
                Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                Name = "C# Corner",
                Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                Name = "Sam",
                Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                Name = "Sri",
                Amount = rand.Next(0, 200)
            });
            //     ((PieSeries)PieChart.Series[0] ).ItemsSource = records;
            //    ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = records;
            //   ((LineSeries)lineChart.Series[0] ).ItemsSource = records;
        }
    }
}
