using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

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
        ObservableCollection<costPerHour> costData { get; set; }
        public estimatedCost(string name = null)
        {
            if (name == null)
                name = "";
            DevName = name;
            this.InitializeComponent();
            try
            {
                costData = new ObservableCollection<costPerHour>();
                for (int i = 0; i < 24; i++)
                {
                    costData.Add(new costPerHour(i+1, i * 10));
                }

                ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = costData;
                //((ColumnSeries)ColumnChart.Series[0]).DependentRangeAxis = new LinearAxis()
                //{
                //    Maximum = 350,
                //    Minimum = 10,
                //    Orientation = AxisOrientation.Y,
                //    Interval = 40,
                //    ShowGridLines = true,

                //};

                //((ColumnSeries)ColumnChart.Series[0]).IndependentAxis = new LinearAxis()
                //{
                //    Maximum = 35,
                //    Minimum = 1,
                //    Orientation = AxisOrientation.X,
                //    Interval = 3,
                //    ShowGridLines = true,

                //};


               // ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = costData;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Data);
            }
        }




        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new specialDev(DevName);
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
