using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace GuzzlerMobileApp.views
{

    public sealed partial class realTimePower : Page, INotifyPropertyChanged
    {
        public string DevName { get; private set; }
        private string realTimeViewLink;
        public string RealTimeViewLink
        {
            get { return realTimeViewLink; }
            private set
            {
                if (realTimeViewLink != value)
                    realTimeViewLink = value;
                NotifyPropertyChanged("RealTimeViewLink");
            }
        }
        public realTimePower(string name = null)
        {
            if (name == null)
                name = "";
            DevName = name;
            RealTimeViewLink = App.devicesMan.getDeviceByName(DevName).RealTimeLink;
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new specialDev(DevName);
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
