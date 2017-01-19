using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GuzzlerMobileApp.views;
using GuzzlerMobileApp.DataModel;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuzzlerMobileApp.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class regDev : Page, INotifyPropertyChanged
    {
        public regDev()
        {
            this.InitializeComponent();
        }

        private string devName = "";
        public string DevName
        {
            get { return devName; }
            set
            {
                if (devName != value)
                    devName = value;
                NotifyPropertyChanged("DevName");
            }

        }
        private string manufacturer = "";
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (manufacturer != value)
                    manufacturer = value;
                NotifyPropertyChanged("Manufacturer");
            }
        }
        private string guzzlerId = "";
        public string GuzzlerId
        {
            get { return guzzlerId; }
            set
            {
                if (guzzlerId != value)
                    guzzlerId = value;
                NotifyPropertyChanged("GuzzlerId");
            }
        }
        private string devType = "";
        public string DevType
        {
            get { return devType; }
            set
            {
                if (devType != value)
                    devType = value;
                NotifyPropertyChanged("DevType");
            }
        }
        private string model = "";
        public string Model
        {
            get { return model; }
            set
            {
                if (model != value)
                    model = value;
                NotifyPropertyChanged("Model");
            }
        }
        private string serial = "";
        public string Serial
        {
            get { return serial; }
            set
            {
                if (serial != value)
                    serial = value;
                NotifyPropertyChanged("Serial");
            }
        }



        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new devices();
            Window.Current.Activate();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {

            if (DevName != "" )
                {
                existingDevsModel.existingDevs.Add(DevName);
                existingDevsModel.nickToId.Add(DevName, GuzzlerId);
                App.devicesMan.AzureStoreDevice(App.devicesMan.createNewDevice(guzzlerId, devName, devType, manufacturer, model, serial));

            }
            Window.Current.Content = new devices();
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
