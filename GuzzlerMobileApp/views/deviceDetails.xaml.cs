using GuzzlerMobileApp.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuzzlerMobileApp.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class deviceDetails : Page
    {

        Device dev;
        public deviceDetails(string requestedDeviceName)
        {
            dev = App.devicesMan.getDeviceByName(requestedDeviceName);
            devName = requestedDeviceName;
            guzzlerId = dev.PartitionKey;
            manufacturer = dev.ManufacturerName;
            devType = dev.DeviceType;
            model = dev.DeviceModel;
            serial = dev.SerialNumber;
            timeCreated = "Created On  " + dev.Timestamp.ToLocalTime().ToString();
            this.InitializeComponent();

        }

        private string devName = "";
        public string DevName
        {
            get { return devName; }
            set { }
        }
        private string manufacturer = "";
        public string Manufacturer
        {
            get { return manufacturer; }
            set { }   
          
        }
        private string guzzlerId = "";
        public string GuzzlerId
        {
            get { return guzzlerId; }
            set { }
           
        }
        private string devType = "";
        public string DevType
        {
            get { return devType; }
            set { }       
        }
        private string model = "";
        public string Model
        {
            get { return model; }
            set { }    
        }
        private string serial = "";
        public string Serial
        {
            get { return serial; }
            set { }       
        }
        private string timeCreated = "";
        public string TimeCreated
        {
            get { return timeCreated; }
            set { }       
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new specialDev(dev.RowKey);
            Window.Current.Activate();
        }
    }

}
