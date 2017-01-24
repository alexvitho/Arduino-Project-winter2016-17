using GuzzlerMobileApp.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace GuzzlerMobileApp.views
{

    public partial class devices : Page, INotifyPropertyChanged
    {
        private bool isNextEnabled = false;
        public bool IsNextEnabled
        {
            get { return isNextEnabled; }
            set
            {
                if (isNextEnabled != value)
                {
                    isNextEnabled = value;
                    NotifyPropertyChanged("IsNextEnabled");
                }
            }
        }
        private string chosendev;
        public string ChosenDev
        {
            get { return chosendev; }
            set
            {
                if (chooseDev.SelectedIndex != -1)
                    IsNextEnabled = true;
                else
                    IsNextEnabled = false;
                if (chosendev != value)
                {
                    chosendev = value;
                    NotifyPropertyChanged("ChosenDev");
                }
            }
        }
        private string devToRemove;
        public string DevToRemove
        {
            get { return devToRemove; }
            set
            {
                if (devToRemove != value)
                {
                    devToRemove = value;
                    NotifyPropertyChanged("DevToRemove");
                }
            }
        }
        private List<string> existingDevs;

        public devices()
        {

              existingDevs = existingDevsModel.existingDevs;
            
          
            chosendev = "";
            devToRemove = "";
            InitializeComponent();
            foreach (string it in existingDevs)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = it;
                chooseDev.Items.Add(item);
            }
            foreach (string it in existingDevs)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = it;
                removeDev.Items.Add(item);
            }

        }


        private void regNewDev_click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Window.Current.Content = new regDev();
            Window.Current.Activate();
        }

        private void Next_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Window.Current.Content = new specialDev(chooseDev.SelectionBoxItem as string);
            Window.Current.Activate();

        }


        private void removeDev_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (DevToRemove == null || DevToRemove == "")
                return;
            foreach (ComboBoxItem it in chooseDev.Items)
            {
                if (it.Content.Equals(removeDev.SelectionBoxItem))
                    chooseDev.Items.Remove(it);

            }
            string toRemove = removeDev.SelectionBoxItem as string;
            existingDevsModel.existingDevs.Remove(toRemove);
            removeDev.Items.RemoveAt(removeDev.SelectedIndex);
            App.devicesMan.AzureRemoveDevice(existingDevsModel.nickToId[toRemove], toRemove);
            existingDevsModel.nickToId.Remove(toRemove);
        }
        private void cost_Click(object sender, RoutedEventArgs e)
        {
            
            showMSG.showOkMSG("Thank you for being patient", "It took few seconds to calculate the statistics");

            Window.Current.Content = new estimatedCost();
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
