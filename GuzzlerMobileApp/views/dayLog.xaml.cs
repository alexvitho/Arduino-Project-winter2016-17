
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace GuzzlerMobileApp.views
{

    public sealed partial class dayLog : Page
    {
        public string DevName { get; private set; }
        public string Date { get; private set; }
        private string guzzlerId;
        DateTimeOffset DateChosed;
        public static StorageCredentials credentials = new StorageCredentials("guzzlerstorage", "GQgI4xCFRAHvD4s+4E+QKqPAHAWGgWagsWa6zP3aWfKus8GGJ15n+Fhp0DT9tD6+OzHSGR2Ekf8Twl4w2mfPow==");
        public static CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);
        CloudTable devicesGraphsTable = storageAccount.CreateCloudTableClient().GetTableReference("DeviceGraps");  // Retrieve a reference to the table.
        ObservableCollection<costPerHour> costData { get; set; }



        public dayLog(string specificDate, string devName, DateTimeOffset DateTime)
        {
            if (specificDate == null)
                specificDate = "";
            if (devName == null)
                DevName = "";
            guzzlerId = DataModel.existingDevsModel.nickToId[devName];
            DevName = devName;
            Date = specificDate + " stats";
            DateChosed = DateTime;

            this.InitializeComponent();
            getValuesForDate();
            try {
                costData = new ObservableCollection<costPerHour>();
                for (int i = 0; i < 24; i++)
                {
                    costData.Add(new costPerHour(i + 1, i * 10));
                }

                ((ColumnSeries)ColumnChart.Series[0]).ItemsSource = costData;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Data);
            }
        }

        public List<double> getValuesForDate()
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, guzzlerId);

            // **************************************  date filter ********************************************//
            DateTimeOffset startTime = new DateTimeOffset(DateChosed.Year, DateChosed.Month, DateChosed.Day, 0, 0, 0, new TimeSpan());
            DateTimeOffset endTime = new DateTimeOffset(DateChosed.Year, DateChosed.Month, DateChosed.Day, 23, 59, 59, new TimeSpan());

            string startTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, startTime.LocalDateTime);
            string endTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.LessThanOrEqual, endTime.LocalDateTime);
            string dateFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter, TableOperators.And, startTimeFilter), TableOperators.And, endTimeFilter);
            // ************************************** End of date filter ********************************************//
            // **************************************  power filter ********************************************//
            string powerLow = TableQuery.GenerateFilterConditionForDouble("realPower", QueryComparisons.GreaterThanOrEqual, 1);
            string powerHigh = TableQuery.GenerateFilterConditionForDouble("realPower", QueryComparisons.LessThanOrEqual, 2);
            string powerFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter, TableOperators.And, powerHigh), TableOperators.And, powerLow);
            // ************************************** End of power filter ********************************************//

            var query = new TableQuery<DynamicTableEntity>().Where(dateFilter).Select(new string[] {"Timestamp", "realPower"});

            var queryOutput = devicesGraphsTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
            var results = queryOutput.Result.Results;
            List<double> tmp = new List<double>();
            List<DateTime> tmp1 = new List<DateTime>();




            foreach (var entity in results)
            {
                tmp.Add((Double.Parse((entity.Properties["realPower"].PropertyAsObject).ToString())));
                tmp1.Add((entity.Timestamp.LocalDateTime));

                DataModel.existingDevsModel.nickToId.Add(entity.RowKey, entity.PartitionKey);
            }

            return tmp;

        }



        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new historyLog(DevName);
            Window.Current.Activate();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
