
using GuzzlerMobileApp.Common;
using GuzzlerMobileApp.DataModel;
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

    public sealed partial class dayLog : Page, INotifyPropertyChanged
    {
        public string DevName { get; private set; }
        public string Date { get; private set; }
        DateTimeOffset DateChosed;
		ObservableCollection<costPerHour> costData { get; set; }
        List<powerTimeItem> powerData { get; set; }
        public DateTime maxTimeVal { get; set; }
        public DateTime minTimeVal { get; set; }
        DateTime todayAndNow;
		deviceGraphAnalysis analysis = new deviceGraphAnalysis();
		
        public dayLog(string specificDate, string devName, DateTimeOffset DateTime)
        {
            if (specificDate == null)
                specificDate = "";
            if (devName == null)
                DevName = "";

            DevName = devName;
            Date = specificDate + " stats";
            DateChosed = DateTime;
            todayAndNow = DateTimeOffset.Now.ToLocalTime().Date;
            this.InitializeComponent();
			powerData = analysis.getPowerValuesForDate(DateTime, devName);
            setCharts();
        }

        private void setCharts()
        {
            try
            {

                if (DateChosed.ToLocalTime().Date.Equals(todayAndNow))
                {
                    maxTimeVal = DateTimeOffset.Now.ToLocalTime().DateTime;
                }
                else
                    maxTimeVal = new DateTime(2017, 1, 21, 23, 59, 59);
                minTimeVal = new DateTime(2017, 1, 21, 1, 0, 0);

                costData = new ObservableCollection<costPerHour>();
                for (int i = 0; i < 24; i++)
                {
                    costData.Add(new costPerHour(i + 1, i * 10));
                }
                //powerData = new ObservableCollection<powerTimeItem>();
                //int j = 0;
                //for (int i = 0; i < 60; i++)
                //{
                //    if (i < 30)
                //        powerData.Add(new powerTimeItem(new DateTime(2017, 1, 21, 1, (i) % 50, (i + 8) % 50), i * 10));
                //    else
                //    {
                //        powerData.Add(new powerTimeItem(new DateTime(2017, 1, 21, 1, (i) % 50, (i + 8) % 50), j * 10));
                //        j++;
                //    }
                //}
                ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = costData;
                ((LineSeries)LineChart.Series[0]).ItemsSource = powerData;
                ((LineSeries)LineChart.Series[0]).IndependentAxis = new DateTimeAxis()
                {
                    IntervalType = DateTimeIntervalType.Minutes,
                    Orientation = AxisOrientation.X,
                    Maximum = maxTimeVal,
                    Minimum = minTimeVal,
                    ShowGridLines = true,
                };
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Data);
            }
        }

     



        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new historyLog(DevName);
            Window.Current.Activate();

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

        private void Pie_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new dailyPie(DateChosed.ToLocalTime().DateTime, DevName);
            Window.Current.Activate();
        }
    }
}
