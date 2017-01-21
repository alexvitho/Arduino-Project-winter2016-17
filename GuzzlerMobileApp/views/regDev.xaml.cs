using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GuzzlerMobileApp.DataModel;
using System;
using Windows.UI.Popups;

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
                    guzzlerId = value.Trim();
                    NotifyPropertyChanged("GuzzlerId");
                }
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

        private bool IdIsValid(string value)
        {
            if (!value.StartsWith("GD")) // start with GD
                return wrongIDFormat();
            string[] strs = value.Split('-');
            // there is only one "-" and the 2-nd part is 2 chars length
            if (strs.Length != 2 || strs[1].Length != 2)
                return wrongIDFormat();
            int year = 0;
            int serial = 0;
            // the last 2 chars are a year suffix 00 - 99
            if ((!int.TryParse(strs[1], out year)) || (year < 0))
                return wrongIDFormat();
            // the serial number is right after GD , format: 000 and grater 
            string ser = strs[0].Substring(2);
            if (ser.Length<3 ||(!int.TryParse(ser, out serial)) || (serial < 0))
                return wrongIDFormat();
            if (existingDevsModel.nickToId.ContainsValue(value))
            {
                showMSG.showOkMSG("Wrong ID", "This ID already exists!");
                return false;
            }
            return true;
        }

        private bool wrongIDFormat()
        {
            showMSG.showOkMSG("Wrong Guzzler ID", "The ID must be in the format: GDXXX-YY, where XXX is a number, at least 3 digits long, and YY is the last 2 digits of the year!");
            guzzlerId = "";
            return false;
        }

        private bool NameIsValid(string value)
        {
            if (value.Equals(""))
            {
                showMSG.showOkMSG("Wrong Nick", "Please give a nick to your device!");
                return false;
            }
            if (existingDevsModel.nickToId.ContainsKey(value))
            {
                showMSG.showOkMSG("Wrong Nick", "This nick already exists!");
                return false;
            }
            return true;
        }
        private void regButton_Click(object sender, RoutedEventArgs e)
        {

            if (!NameIsValid(DevName) || !IdIsValid(GuzzlerId))
                return;
            existingDevsModel.existingDevs.Add(DevName);
            existingDevsModel.nickToId.Add(DevName, GuzzlerId);
            App.devicesMan.AzureStoreDevice(App.devicesMan.createNewDevice(guzzlerId, devName, devType, manufacturer, model, serial));
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
    static public class showMSG
    {
        public static async void showOkMSG(string title, string message)
        {
            var dialog = new message();
          //  var dialog = new MessageDialog(message);
            dialog.Title = title;
            dialog.Msg = message;
         //   dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            await dialog.ShowAsync();
        }
    }
}

