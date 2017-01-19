using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace GuzzlerMobileApp.views
{

    public sealed partial class checkNow : Page
    {

        public string DevName { get; private set; }
      
        public checkNow(string name = null)
        {
            if (name == null)
                name = "";
            DevName = name;
            this.InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new specialDev(DevName);
            Window.Current.Activate();
        }

        private void WebView_LoadCompleted(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            
           
        }
    }
}
