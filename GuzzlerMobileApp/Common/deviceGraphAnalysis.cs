﻿using GuzzlerMobileApp.DataModel;
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
        CloudTable taarifTable;
        public deviceGraphAnalysis()
        {
            credentials = new StorageCredentials("guzzlerstorage2", "Eaa9uDqM5n5SHE8GfAHqw5yLxuSxIl4ulIt9IxTnB2s2ePfY1C1WL9OMmmyJw1jRkRYbpnM3ZQcOnvmZE8BY2Q==");
            storageAccount = new CloudStorageAccount(credentials, true);
            devicesGraphsTable = storageAccount.CreateCloudTableClient().GetTableReference("GuzzlerDevices"); // Table that sotres devices Data History 
            taarifTable = storageAccount.CreateCloudTableClient().GetTableReference("ElectricityTariff"); // Electricity taarif table
        }

        // function to create a string representing the date day/month/year
        public static string dateToString(DateTime date)
        {
            return (date == null) ? "" : date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString();
        }

        public List<powerTimeItem> getPowerValuesForDate(DateTimeOffset DateChosed, string deviceName)
        {
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, existingDevsModel.nickToId[deviceName]);

            // **************************************  date filter ********************************************//
            DateTimeOffset startTime;
            DateTimeOffset endTime;
            if (DateChosed.TimeOfDay.Hours < 2) // in case that choosen date is not changed yet because UTC time
            {
                DateTimeOffset day = DateChosed.AddHours(-2);
                startTime = new DateTimeOffset(day.Year, day.Month, day.Day, 22, 0, 0, new TimeSpan());
                endTime = new DateTimeOffset(DateChosed.Year, DateChosed.Month, DateChosed.Day, 21, 59, 59, new TimeSpan());
            }
            else
            {

                DateTimeOffset day = DateChosed.AddHours(-2);
                DateTimeOffset prevDay = new DateTimeOffset(day.Year, day.Month, day.Day, 0, 0, 0, new TimeSpan());
                day = prevDay.AddHours(-2);
                startTime = new DateTimeOffset(day.Year, day.Month, day.Day, 22, 0, 0, new TimeSpan());
                endTime = new DateTimeOffset(DateChosed.Year, DateChosed.Month, DateChosed.Day, 21, 59, 59, new TimeSpan());
            }
            string startTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, startTime);
            string endTimeFilter = TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.LessThanOrEqual, endTime);
            string dateFilter = TableQuery.CombineFilters(TableQuery.CombineFilters(partitionFilter, TableOperators.And, startTimeFilter), TableOperators.And, endTimeFilter);
            // ************************************** End of date filter ********************************************//
            var query = new TableQuery<DynamicTableEntity>().Where(dateFilter).Select(new string[] { "Timestamp", "realPower" });
            var queryOutput = devicesGraphsTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
            var results = queryOutput.Result.Results;
            List<powerTimeItem> retValue = new List<powerTimeItem>();
            foreach (var entity in results)
            {
                retValue.Add(new powerTimeItem(entity.Timestamp.LocalDateTime, (Double.Parse((entity.Properties["realPower"].PropertyAsObject).ToString()))));
            }
            retValue.Sort();
            return retValue;
        }
        public double[] getDailyPowerPerHour(DateTimeOffset DateChosed, string deviceName)
        {
            List<powerTimeItem> dailyPower = getPowerValuesForDate(DateChosed, deviceName);
            double[] hourlyPower = new double[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] numOfsamples = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (var entity in dailyPower)
            {
                hourlyPower[entity.time.Hour] += entity.value;
                numOfsamples[entity.time.Hour]++; ;
            }
            for  (int i = 0 ; i<24; ++i )
            {
                if (numOfsamples[i] != 0)
                {
                    hourlyPower[i] /= numOfsamples[i];
                }
                else
                {
                    hourlyPower[i] = 0;
                }
            }
            return hourlyPower;
        }
        public List<powerTimeItem> getAverageEvery10SAmples(List<powerTimeItem> dailyPower)
        {
            List<powerTimeItem> dailyAveragePower = new List<powerTimeItem>();
            int i = 0;
           double average = 0;
            foreach (var entity in dailyPower)
            {
                average += entity.value;
                i++;
                if (i == 10)
                {
                    var temp = new powerTimeItem(entity.time, (average /= 10));
                    dailyAveragePower.Add(temp);
                    i = 0;
                }
                
            }
            return dailyAveragePower;
        }

        // returns the sum of the power consumed in one day 
        public double getDailyPower(DateTimeOffset DateChosed, string deviceName)
        {
            double[] hourlyPower = getDailyPowerPerHour(DateChosed, deviceName);
            double overalSum = 0;
            for (int i = 0; i < 24; ++i)
            {
                overalSum += hourlyPower[i];
            }
            return (overalSum );
        }
        public string getValueFromTable(string pKey, string rKey, string column, CloudTable table)
        {
            string countryFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pKey);
            string yearFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, rKey);
            string taarifFilter = TableQuery.CombineFilters(countryFilter, TableOperators.And, yearFilter);
            var query = new TableQuery<DynamicTableEntity>().Where(taarifFilter).Select(new string[] { column });
            var queryOutput = table.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null).GetAwaiter().GetResult();
            var results = queryOutput.Results;
            foreach (var entity in results)
            {
                return (entity.Properties[column].PropertyAsObject).ToString();
            }
            return null;
        }
        public double[] getMonthlyPowerPerDay(DateTimeOffset date, string deviceName)
        {
            int numOfDays = DateTime.DaysInMonth(date.Year, date.Month);
            double[] dailyPower = new double[numOfDays];
            for (int i = 0; i < numOfDays; i++)
            {
                dailyPower[i] = 0;
            }
            DateTimeOffset iterating_date = new DateTimeOffset(date.Year, date.Month,1,10,0 ,0 ,new TimeSpan());
            for (int i = 0; i < numOfDays; i++)
            {

                dailyPower[i] = getDailyPower(iterating_date, deviceName);
                iterating_date= iterating_date.AddDays(1);
            }
                return dailyPower;
        }
        public double getMonthPower(DateTimeOffset date, string deviceName)
        {
            int numOfDays = DateTime.DaysInMonth(date.Year, date.Month);
            double[] dailyPower = getMonthlyPowerPerDay(date, deviceName);
            double overalSum = 0;
            for (int i = 0; i < numOfDays; i++)
            {
                overalSum += dailyPower[i];
            }
            return( overalSum);
        }

        public double getElectricityTaarif(string country , string year)
        {
            return double.Parse(getValueFromTable( country, year, "KwCost", taarifTable));
        }

        public List<piePowerItem> getDailyPowerPie(DateTimeOffset date)
        {
            List<piePowerItem> pieList = new List<piePowerItem>();     
            foreach(string name in (new deviceManager()).getLocalNames())
            {
                pieList.Add(new piePowerItem(name, getDailyPower(date, name)));

            }
             return pieList;
        }
        public List<piePowerItem> getMonthlyPowerPie(DateTimeOffset date)
        {
            List<piePowerItem> pieList = new List<piePowerItem>();
            foreach (string name in (new deviceManager()).getAllDevicesNames())
            {
                pieList.Add(new piePowerItem(name, getMonthPower(date, name)));

            }
            return pieList;
        }


    }
}
