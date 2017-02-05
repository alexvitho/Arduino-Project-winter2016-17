using GuzzlerMobileApp.Common;
using GuzzlerMobileApp.DataModel;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Uwp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace GuzzlerMobileApp.views
{

    public sealed partial class dailyLog : Page
    {


        public string DevName { get; private set; }
        public string Date { get; private set; }
        DateTimeOffset DateChosed;
        List<powerTimeItem> powerData { get; set; }
        public DateTime maxTimeVal { get; set; }
        public DateTime minTimeVal { get; set; }
        DateTime todayAndNow;
        deviceGraphAnalysis analysis = new deviceGraphAnalysis();


        public dailyLog(string specificDate, string devName, DateTimeOffset DateTime)
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
            DataContext = this;
        }

        public Func<double, string> Formatter { get; set; }
        public SeriesCollection Series { get; set; }
        public string[] Labels { get; set; }

        private void setCharts()
        {
            try
            {
                if (powerData.Count == 0)
                {
                    showMSG.showOkMSG("NO INFO", "Sorry, no data for " + DevName + " on " + deviceGraphAnalysis.dateToString(DateChosed.Date));
                    return;
                }
                // there is at least one data point
                minTimeVal = powerData.ToArray()[0].time;
                if (DateChosed.ToLocalTime().Date.Equals(todayAndNow))
                    maxTimeVal = DateTimeOffset.Now.ToLocalTime().DateTime;

                else
                    maxTimeVal = powerData.ToArray()[powerData.Count - 1].time;
                if (powerData.Count == 1)
                {
                    minTimeVal = minTimeVal.AddHours(-1);
                    maxTimeVal = maxTimeVal.AddHours(1);
                }
                var dayConfig = Mappers.Xy<powerTimeItem>()
                    .X(powerTimeItem => (double)(powerTimeItem.time.Ticks) / TimeSpan.FromHours(1).Ticks)
                          .Y(powerTimeItem => powerTimeItem.value);
                Series = new SeriesCollection(dayConfig)
                  {
                new LineSeries
                {
                    Values = new ChartValues<powerTimeItem>(powerData)
                 ,
                    Fill = new SolidColorBrush(Windows.UI.Colors.Transparent)
                    ,
                    Stroke =new SolidColorBrush(Windows.UI.Colors.Blue),
                    StrokeThickness = 1,
                    Title="",LabelPoint= new Func<ChartPoint, string>(p => Math.Round(p.Y,3).ToString()+" kW" )
                    
                },
                 };
                

                Formatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("t");
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
        private void Column_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new dailyColumn(DateChosed.ToLocalTime().DateTime, DevName);
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