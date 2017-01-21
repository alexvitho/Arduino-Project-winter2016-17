using GuzzlerMobileApp.DataModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using static GuzzlerMobileApp.Common.deviceGraphAnalysis;

namespace GuzzlerMobileApp.views
{


    public sealed partial class checkNow : Page, INotifyPropertyChanged
    {

        public string DevName { get; private set; }
        public double intYVal = 100;// { get; set; }
        public double maxYVal = 1000;// { get; set; }
        public double minYVal = 1;//{ get; set; }
        public double intXVal { get; set; }
        public double maxXVal = 130;// { get; set; }
        public double minXVal = 1;// { get; set; }
      

        public ObservableCollection<powerItem> Data1 { get; private set; }
        public ObservableCollection<powerItem> Data2 { get; private set; }
        public checkNow(string name = null)
        {
            try
            {
                if (name == null)
                    name = "";
                DevName = name;
                this.InitializeComponent();
                intXVal = 12;
                Data1 = new ObservableCollection<powerItem>();
                for (int i = 0; i < 130; i++)
                {
                    Data1.Add(new powerItem(i, i * 10));
                }
                Data2 = new ObservableCollection<powerItem>();

                Data2.Add(new powerItem(1, 0.64));
                Data2.Add(new powerItem(2, 0.36));

                ((LineSeries)LineChart.Series[0]).ItemsSource = Data1;
                ((LineSeries)LineChart.Series[0]).DependentRangeAxis = new LinearAxis()
                {
                    Maximum = maxYVal,
                    Minimum = minYVal,
                    Orientation = AxisOrientation.Y,
                    Interval = intYVal,
                    ShowGridLines = true,
                };

                ((LineSeries)LineChart.Series[0]).IndependentAxis = new LinearAxis()
                {
                    Maximum = maxXVal,
                    Minimum = minXVal,
                    Orientation = AxisOrientation.X,
                    Interval = intXVal,
                    ShowGridLines = true,
                };
                // ((PieSeries)PieChart.Series[0]).ItemsSource = Data2;

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
