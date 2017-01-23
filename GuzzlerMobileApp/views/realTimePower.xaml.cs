using GuzzlerMobileApp.Common;
using LiveCharts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace GuzzlerMobileApp.views
{
    public class MeasureModel
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }

    }
    public sealed partial class realTimePower : Page, INotifyPropertyChanged
    {

        static StorageCredentials credentials;
        static CloudStorageAccount storageAccount;
        CloudTable devicesGraphsTable;
        deviceGraphAnalysis analysis;
        private double _axisMin;
        private double _axisMax;
        private string devName = "";

        public string DevName
        {
            get { return devName; }
            set
            {
                if (devName != value)
                    devName = value;
            }

        }

        public realTimePower(string DeviceName)
        {

            credentials = new StorageCredentials("guzzlerstorage", "GQgI4xCFRAHvD4s+4E+QKqPAHAWGgWagsWa6zP3aWfKus8GGJ15n+Fhp0DT9tD6+OzHSGR2Ekf8Twl4w2mfPow==");
            storageAccount = new CloudStorageAccount(credentials, true);
            devicesGraphsTable = storageAccount.CreateCloudTableClient().GetTableReference("DeviceGrapsReal");  // Retrieve a reference to the table.
            analysis = new deviceGraphAnalysis();
            DevName = DeviceName;

            this.InitializeComponent();
            var mapper = LiveCharts.Configurations.Mappers.Xy<MeasureModel>()
                  .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                  .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);


            //the values property will store our values array
            ChartValues = new ChartValues<MeasureModel>();

            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)(value)).ToString("mm:ss");
            valueFormatter = value => Math.Round(value, 3).ToString();
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            SetAxisLimits(DateTime.Now);

            //The next code simulates data changes every 300 ms
            Timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(300)
            };
            Timer.Tick += TimerOnTick;
            IsDataInjectionRunning = false;
            R = new Random();

            DataContext = this;
        }

        public ChartValues<MeasureModel> ChartValues { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public Func<double, string> valueFormatter { get; set; }
        public double AxisStep { get; set; }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        public DispatcherTimer Timer { get; set; }
        public bool IsDataInjectionRunning { get; set; }
        public Random R { get; set; }

        private void RunDataOnClick(object sender, RoutedEventArgs e)
        {
            if (IsDataInjectionRunning)
            {
                Timer.Stop();
                IsDataInjectionRunning = false;
            }
            else
            {
                Timer.Start();
                IsDataInjectionRunning = true;
            }
        }
        double tmpVal;
        private void TimerOnTick(object sender, object eventArgs)
        {
            var now = DateTime.Now;
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, devName); // should be guzzlerId
            string startTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, now);
            string dateFilter = (TableQuery.CombineFilters(partitionFilter, TableOperators.And, startTimeFilter));
            var query = new TableQuery<DynamicTableEntity>().Where(dateFilter).Select(new string[] { "realPower" });
            var queryOutput = devicesGraphsTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
            var results = queryOutput.Result.Results;


            foreach (var entity in results)
            {
                tmpVal = (Double.Parse((entity.Properties["realPower"].PropertyAsObject).ToString()));
                break;
            }
            ChartValues.Add(new MeasureModel
            {
                DateTime = now,
                Value = tmpVal
               


            });

            SetAxisLimits(now);

            //lets only use the last 30 values
            if (ChartValues.Count > 30) ChartValues.RemoveAt(0);
        }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks; // lets force the axis to be 100ms ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(8).Ticks; //we only care about the last 8 seconds
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new specialDev(devName);
            Window.Current.Activate();
        }


    }
}
