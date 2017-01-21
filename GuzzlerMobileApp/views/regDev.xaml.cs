using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GuzzlerMobileApp.DataModel;
using System;

namespace GuzzlerMobileApp.views
{

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
                {
                    if (IdIsValid(value))
                        guzzlerId = value.Trim();
                    else
                        guzzlerId = "";
                    NotifyPropertyChanged("GuzzlerId");
                }
            }
        }

        private bool IdIsValid(string value)
        {
            if (!value.StartsWith("GD")) // start with GD
                return false;
            string[] strs = value.Split('-');
            // there is only one "-" and the 2-nd part is 2 chars length
            if (strs.Length != 2 || strs[1].Length!=2) 
                return false;
            int year = 0;
            int serial = 0;
            return true;
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

            if (DevName != "")
            {
                if (existingDevsModel.nickToId.ContainsValue(GuzzlerId))
                    return;
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
