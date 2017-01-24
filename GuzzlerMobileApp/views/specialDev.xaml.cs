using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace GuzzlerMobileApp.views
{

    public sealed partial class specialDev : Page
    {

        public string DeviceName { get; private set; }

        public specialDev(string name = null)
        {
            DeviceName = (name == null) ? "" : name;
            this.InitializeComponent();
        }

        private void powerConsumption_Click(object sender, RoutedEventArgs e)
        {
            if (App.devicesMan.cheCkifDeviceStreamingLive(DeviceName) == false)
            {
                showMSG.showOkMSG("No Live Stream Available", "Please check your azzure storage connection");
                return;
            }
            Window.Current.Content = new realTimePower(DeviceName);
            Window.Current.Activate();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new historyLog(DeviceName);
            Window.Current.Activate();
        }
        private void deviceDetails_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new deviceDetails(DeviceName);
            Window.Current.Activate();
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new devices();
            Window.Current.Activate();
        }

    }
}
