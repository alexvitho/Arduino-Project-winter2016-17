
using GuzzlerMobileApp.Common;
using GuzzlerMobileApp.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

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
        private Boolean dataExists = true;
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
            if (!dataExists)
                backButton_Click(this, null);
        }

        private void setCharts()
        {
            try
            {


                if (powerData.Count == 0)
                {
                    showMSG.showOkMSG("NO INFO", "Sorry, no data for " + DevName + " on " + deviceGraphAnalysis.dateToString(DateChosed.Date));
                    dataExists = false;
                    return;
                }
                // there is at least one data point
                minTimeVal= powerData.ToArray()[0].time;
                if (DateChosed.ToLocalTime().Date.Equals(todayAndNow))
                    maxTimeVal = DateTimeOffset.Now.ToLocalTime().DateTime;
               
                else
                    maxTimeVal = powerData.ToArray()[powerData.Count - 1].time;
                if (powerData.Count == 1)
                {
                    minTimeVal = minTimeVal.AddHours(-1);
                    maxTimeVal= maxTimeVal.AddHours(1);
                }
          
                costData = new ObservableCollection<costPerHour>();
                for (int i = 0; i < 24; i++)
                {
                    costData.Add(new costPerHour(i + 1, i * 10));
                }

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
        private void Pie_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new dailyPie(DateChosed.ToLocalTime().DateTime, DevName);
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


    }
}
