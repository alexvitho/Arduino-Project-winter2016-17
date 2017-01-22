using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static GuzzlerMobileApp.Common.deviceGraphAnalysis;

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
            selectedDate = dateToString(date.DateTime);
            dateChosed_Click();
        }

        private void dateChosed_Click()
        {
            DateTime todayAndNow = DateTimeOffset.Now.ToLocalTime().Date;
            if (date.ToLocalTime().Date.CompareTo(todayAndNow) > 0)
            {
                showMSG.showOkMSG("NO INFO","Sorry, still can not look into the future!");
                return;
            }
            //  Window.Current.Content = new dayLog(selectedDate, DevName, date);
            Window.Current.Content = new dailyLog(selectedDate, DevName, date);
            Window.Current.Activate();

        }
    }


}
