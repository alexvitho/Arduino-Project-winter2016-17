using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GuzzlerMobileApp.views
{

    public sealed partial class historyLog : Page
    {
        public string DevName { get; private set; }
        public string selectedDate;
       private DateTimeOffset date;

       


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
             date = args.AddedDates.First();
            selectedDate = date.Day.ToString() + "/" + date.Month + "/" + date.Year;
            dateChosed_Click();
        }

        private void dateChosed_Click()
        {
            Window.Current.Content = new dayLog(selectedDate, DevName,date);
            Window.Current.Activate();

        }
    }


}
