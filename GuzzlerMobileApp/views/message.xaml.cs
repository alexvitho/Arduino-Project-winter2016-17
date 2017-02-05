using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace GuzzlerMobileApp.views
{
    public enum MyResult
    {
        Yes,
        No,
        Cancle,
        Nothing
    }
    public sealed partial class message : ContentDialog
    {
        public message()
        {
            this.InitializeComponent();
            this.Result = MyResult.Nothing;
        }

        public MyResult Result { get; set; }
        public string mTitle { get; set; }
        public string Msg { get; set; }
        public Visibility yesVis = Visibility.Collapsed;
        public Visibility noVis = Visibility.Visible;
        public Visibility cancelVis = Visibility.Collapsed;
        public string btnOkNo = "OK";
        // Handle the button clicks from dialog
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Yes;
            // Close the dialog
            dialog.Hide();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.No;
            // Close the dialog
            dialog.Hide();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Cancle;
            // Close the dialog
            dialog.Hide();
        }
    }
}

