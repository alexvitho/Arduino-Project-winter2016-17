using GuzzlerMobileApp.DataModel;
using GuzzlerMobileApp.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GuzzlerMobileApp.Common
{
    class controller
    {
        private Frame rootFrame = null;
        private UIElement currentWin = null;
        public UIElement CurrentWin
        {
            get { return currentWin; }
            set
            {
                currentWin = value;
            }
        }

        public controller()
        {
            CurrentWin = Window.Current.Content;

            if (rootFrame == null)
            {
                CurrentWin = Window.Current.Content = new devices();
                Window.Current.Activate();

            }
        }


    }
}
