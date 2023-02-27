using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using JET.View.BurgerMenu;
using JET.View.Burger;

namespace JET.ViewModel
{
    public class VMLogin: BaseViewModel
    {

        #region Variables
        string _userName;
        string _password;
        #endregion

        #region Objetos
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        #endregion

        public VMLogin (INavigation navigation)
        {
            Navigation = navigation;
        }

        #region Procesos
        public bool ValidateUser => UserName == "admin" && Password == "123";

        public async Task Login ()
        {
            bool IsValid = ValidateUser;

            if (IsValid)
            {
                await Navigation.PushAsync(new NavigationPage(new BurgerMenu()));
                // await Shell.Current.GoToAsync($"//{nameof(ApplicationShell)}");
            }
            else
            {
                await DisplayAlert("Error", "Usuario y/o contraseña erroneas", "Aceptar");
            }

        }
        #endregion

        #region Commands
        public ICommand LoginCommand => new Command(async () => await Login());
        #endregion
    }
}
