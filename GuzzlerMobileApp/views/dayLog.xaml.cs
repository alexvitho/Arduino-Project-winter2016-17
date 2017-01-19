
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuzzlerMobileApp.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class dayLog : Page 
    {
        public string DevName { get; private set; }
        public string Date { get; private set; }


        public dayLog(string specificDate , string devName )
        {
            if (specificDate == null)
                specificDate = "";
            if (devName == null)
                DevName = "";
            DevName = devName;
            Date = specificDate + " stats" ;
            this.InitializeComponent();
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = new historyLog(DevName);
            Window.Current.Activate();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
