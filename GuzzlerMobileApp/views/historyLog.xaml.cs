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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuzzlerMobileApp.views
{

    public sealed partial class historyLog : Page
    {
        public string DevName { get; private set; }
        public string selectedDate;

        public historyLog(string name = null)
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


        private void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            var date = args.AddedDates.First();
            selectedDate = date.Day.ToString() + "/" + date.Month + "/" + date.Year;
            dateChosed_Click();
        }

        private void dateChosed_Click()
        {
            Window.Current.Content = new dayLog(selectedDate, DevName);
            Window.Current.Activate();

        }
    }


}
