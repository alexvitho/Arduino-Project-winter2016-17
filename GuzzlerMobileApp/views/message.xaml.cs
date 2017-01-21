using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

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

