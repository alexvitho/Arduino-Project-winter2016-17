
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuzzlerMobileApp.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class dayLog : Page
    {
        public string DevName { get; private set; }
        public string Date { get; private set; }
        private string guzzlerId;
        DateTimeOffset DateTimeOffsetVal;
        public static StorageCredentials credentials = new StorageCredentials("guzzlerstorage", "GQgI4xCFRAHvD4s+4E+QKqPAHAWGgWagsWa6zP3aWfKus8GGJ15n+Fhp0DT9tD6+OzHSGR2Ekf8Twl4w2mfPow==");
        public static CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);
        CloudTable devicesGraphsTable = storageAccount.CreateCloudTableClient().GetTableReference("DeviceGraps");  // Retrieve a reference to the table.



        public dayLog(string specificDate, string devName, DateTimeOffset DateTime)
        {
            if (specificDate == null)
                specificDate = "";
            if (devName == null)
                DevName = "";
            guzzlerId = DataModel.existingDevsModel.nickToId[devName];
            DevName = devName;
            Date = specificDate + " stats";
            DateTimeOffsetVal = DateTime;

            this.InitializeComponent();
            getValuesForDate();
        }

        public List<string> getValuesForDate()
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, guzzlerId);

            // **************************************  date filter ********************************************//
            DateTimeOffset startTime = new DateTimeOffset(2017, 1, 20, 0,0, 0, new TimeSpan(2, 0, 0));
            DateTimeOffset endTime = new DateTimeOffset(2017, 1, 20, 23, 59, 59, new TimeSpan(2, 0, 0));

            string startTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, startTime);
            string endTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.LessThanOrEqual, endTime);
            string dateFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter, TableOperators.And, startTimeFilter), TableOperators.And, endTimeFilter);
            // ************************************** End of date filter ********************************************//
            // **************************************  power filter ********************************************//
            string powerLow = TableQuery.GenerateFilterConditionForDouble("realPower", QueryComparisons.GreaterThanOrEqual, 1);
            string powerHigh = TableQuery.GenerateFilterConditionForDouble("realPower", QueryComparisons.LessThanOrEqual, 2);
            string powerFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter, TableOperators.And, powerHigh), TableOperators.And, powerLow);
            // ************************************** End of power filter ********************************************//

            var query = new TableQuery<DynamicTableEntity>().Where(dateFilter);

            var queryOutput = devicesGraphsTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(new TableQuery<DynamicTableEntity>().Where(dateFilter), null);
            var results = queryOutput.Result;
            List<string> tmp = new List<string>();




            foreach (var entity in results)
            {
                tmp.Add(entity.RowKey);
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
