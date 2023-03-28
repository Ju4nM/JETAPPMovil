using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMAppShell: BaseViewModel
    {
        public VMAppShell (INavigation nav)
        {
            Navigation = nav;
        }

        private async Task LogOut()
        {
            await Shell.Current.GoToAsync("//LoginView");
        }

        public ICommand LogOutCommand => new Command(async() => await LogOut());
    }
}
