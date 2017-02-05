using GuzzlerMobileApp.views;
using Windows.UI.Xaml;

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
            Window.Current.Activate();
        }


    }
}
