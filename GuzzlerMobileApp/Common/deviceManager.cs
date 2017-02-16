using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;

namespace GuzzlerMobileApp.Common
{
    // This is the Device structure That will be stored in the Azzure table
    public class Device : TableEntity
    {
        public Device(string guzzlerId, string deviceName)
        {
            this.PartitionKey = guzzlerId;
            this.RowKey = deviceName;
        }

        public Device() { }
        public string DeviceType { get; set; }
        public string ManufacturerName { get; set; }
        public string DeviceModel { get; set; }
        public string SerialNumber { get; set; }
        public string RealTimeLink { get; set; }
    }
    
    public class deviceManager
    {
        
        public static StorageCredentials credentials = new StorageCredentials("guzzlerstorage2", "Eaa9uDqM5n5SHE8GfAHqw5yLxuSxIl4ulIt9IxTnB2s2ePfY1C1WL9OMmmyJw1jRkRYbpnM3ZQcOnvmZE8BY2Q==");
        public static CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);
        CloudTable devicesTable = storageAccount.CreateCloudTableClient().GetTableReference("RegisteredDevices");  // Retrieve a reference to devices details table.
        CloudTable devicesRealTimeTable = storageAccount.CreateCloudTableClient().GetTableReference("GuzzlerDevices");  // Retrieve a reference to device data table
        public Device createNewDevice(string guzzId, string deviceName, string type, string manName, string model, string serial)
        {
            Device newDevice = new Device(guzzId, deviceName);
            newDevice.DeviceType = type;
            newDevice.ManufacturerName = manName;
            newDevice.DeviceModel = model;
            newDevice.SerialNumber = serial;
            newDevice.RealTimeLink = "update from azure"; 
            return newDevice;
        }
        public void AzureStoreDevice(Device dev)
        {
            // Create the table if it doesn't exist.
            devicesTable.CreateIfNotExistsAsync();
            devicesTable.ExecuteAsync(TableOperation.Insert(dev));
        }

        public  Device getDeviceByName(string name)
        {
            // Create a retrieve operation that takes a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<Device>(DataModel.existingDevsModel.nickToId[name], name);
             // Execute the retrieve operation.
            TableResult tableResultValue =  devicesTable.ExecuteAsync(retrieveOperation).GetAwaiter().GetResult();
            return (Device)tableResultValue.Result; 
        }
        public bool cheCkifDeviceStreamingLive(string name)
        {
            string filter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, DataModel.existingDevsModel.nickToId[name]);
            var query = new TableQuery<DynamicTableEntity>().Where(filter).Select(new string[] { "realPower" });
            var queryOutput = devicesRealTimeTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null).GetAwaiter().GetResult();
            var results = queryOutput.Results;
            return (results.Count != 0);
        }


        public async void AzureRemoveDevice(string guzId, string name)
        {
            // Create a retrieve operation that expects a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<Device>(guzId, name);
            // Execute the operation.
            TableResult retrievedResult = await devicesTable.ExecuteAsync(retrieveOperation);
            // Assign the result to a CustomerEntity.
            Device deleteEntity = (Device)retrievedResult.Result;
            // Create the Delete TableOperation.
            if (deleteEntity != null)
            {
                TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
                // Execute the operation.
                await devicesTable.ExecuteAsync(deleteOperation);
            }
        }

        public List<string> getAllDevicesNames()
        {
            var query = new TableQuery<DynamicTableEntity>() { };
            var queryOutput = devicesTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
            var results = queryOutput.Result;
            List<string> tmp = new List<string>();
            foreach (var entity in results)
            {
                tmp.Add(entity.RowKey);
                DataModel.existingDevsModel.nickToId.Add(entity.RowKey, entity.PartitionKey);
            }
            return tmp;
        }
        public List<string> getLocalNames()
        {
            
            List<string> tmp = new List<string>();
            foreach (var entity in DataModel.existingDevsModel.existingDevs)
            {
                tmp.Add(entity);
            }
            return tmp;
        }
    }

}

