using JET.Models;
using JET.View.DashboardViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMUsers: BaseViewModel
    {
        #region Variables
        #endregion

        #region Objetos
        #endregion

        #region Constructor
        public VMUsers (INavigation nav)
        {
            Navigation = nav;
        }
        #endregion

        #region Procesos
        private async void AddUser(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(UserView)}");
        }
        #endregion

        #region Comandos
        public ICommand AddUserCommand => new Command(AddUser);
        #endregion
    }
}
