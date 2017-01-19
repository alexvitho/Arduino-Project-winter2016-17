
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



        public dayLog(string specificDate , string devName, DateTimeOffset DateTime)
        {
            if (specificDate == null)
                specificDate = "";
            if (devName == null)
                DevName = "";
            guzzlerId = DataModel.existingDevsModel.nickToId[devName];
            DevName = devName;
            Date = specificDate + " stats" ;
            DateTimeOffsetVal = DateTime;
            
            this.InitializeComponent();
        }
     
        public List<string> getValuesForDate(string specDate)
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, guzzlerId);
            string date1 = TableQuery.GenerateFilterConditionForDate("Date", QueryComparisons.GreaterThanOrEqual,DateTimeOffsetVal);
            string date2 = TableQuery.GenerateFilterConditionForDate("Date", QueryComparisons.LessThanOrEqual, DateTimeOffsetVal);
            string finalFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter,TableOperators.And,date1),TableOperators.And, date2);

            return null;
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
