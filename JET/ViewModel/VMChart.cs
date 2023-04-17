using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMChart: BaseViewModel
    {
        public VMChart (INavigation nav)
        {
            Navigation = nav;
        }

        public void RedirectToBrowser ()
        {
            Device.OpenUri(new Uri("http://jetapptest.somee.com/#/today-chart"));
            //Launcher.CanOpenAsync(new Uri("http://jetapptest.somee.com/#/today-chart"));
        }

        public ICommand OpenWebAppCommand => new Command(RedirectToBrowser);
    }
}
