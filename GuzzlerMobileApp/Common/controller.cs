using GuzzlerMobileApp.views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GuzzlerMobileApp.Common
{
   public class controller
    {
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

                 Window.Current.Content = new devices();
        //      CurrentWin = Window.Current.Content = new realTimeMeasure();
                Window.Current.Activate();

            
        }


    }
}
