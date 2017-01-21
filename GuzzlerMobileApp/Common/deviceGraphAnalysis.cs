using GuzzlerMobileApp.DataModel;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

namespace GuzzlerMobileApp.Common
{
    public class deviceGraphAnalysis
    {
         static StorageCredentials credentials;
         static CloudStorageAccount storageAccount;
        CloudTable devicesGraphsTable; 
       public deviceGraphAnalysis()
        {
         credentials = new StorageCredentials("guzzlerstorage", "GQgI4xCFRAHvD4s+4E+QKqPAHAWGgWagsWa6zP3aWfKus8GGJ15n+Fhp0DT9tD6+OzHSGR2Ekf8Twl4w2mfPow==");
       storageAccount = new CloudStorageAccount(credentials, true);
        devicesGraphsTable = storageAccount.CreateCloudTableClient().GetTableReference("DeviceGraps");  // Retrieve a reference to the table.
        }

        // function to create a string representing the date day/month/year
        public static string dateToString(DateTime date)
        {
            return (date == null) ? "" : date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
        }

        public List<powerTimeItem> getPowerValuesForDate(DateTimeOffset DateChosed,string deviceName)
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, existingDevsModel.nickToId[deviceName]);

            // **************************************  date filter ********************************************//
            DateTimeOffset startTime;
            DateTimeOffset endTime;
            if (DateChosed.TimeOfDay.Hours < 2) // in case that choosen date is not changed yet because UTC time
            {
                DateTimeOffset day=DateChosed.AddHours(-2);
                startTime = new DateTimeOffset(day.Year, day.Month, day.Day, 22, 0, 0, new TimeSpan());
                endTime = new DateTimeOffset(DateChosed.Year, DateChosed.Month, DateChosed.Day, 21, 59, 59, new TimeSpan());
            } else {
                startTime = new DateTimeOffset(DateChosed.Year, DateChosed.Month, DateChosed.Day, 0, 0, 0, new TimeSpan());
                endTime = new DateTimeOffset(DateChosed.Year, DateChosed.Month, DateChosed.Day, 23, 59, 59, new TimeSpan());
            }

            string startTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, startTime.LocalDateTime);
            string endTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.LessThanOrEqual, endTime.LocalDateTime);
            string dateFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter, TableOperators.And, startTimeFilter), TableOperators.And, endTimeFilter);
            // ************************************** End of date filter ********************************************//
            // **************************************  power filter ********************************************//
            string powerLow = TableQuery.GenerateFilterConditionForDouble("realPower", QueryComparisons.GreaterThanOrEqual, 1);
            string powerHigh = TableQuery.GenerateFilterConditionForDouble("realPower", QueryComparisons.LessThanOrEqual, 2);
            string powerFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter, TableOperators.And, powerHigh), TableOperators.And, powerLow);
            // ************************************** End of power filter ********************************************//
            var query = new TableQuery<DynamicTableEntity>().Where(dateFilter).Select(new string[] { "Timestamp", "realPower" });
            var queryOutput = devicesGraphsTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
            var results = queryOutput.Result.Results;
            List<powerTimeItem> retValue = new List<powerTimeItem>();
      
           foreach (var entity in results)
            {
                retValue.Add(new powerTimeItem(entity.Timestamp.LocalDateTime, (Double.Parse((entity.Properties["realPower"].PropertyAsObject).ToString()))));
            }

            return retValue;
        }
    }
}
