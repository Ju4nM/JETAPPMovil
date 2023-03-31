using JET.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JET.ViewModel
{
    public class VMAppShell: BaseViewModel
    {
        string _userTypeText = string.Empty;
        MUserLogged _userLogged = null;
        public MUserLogged UserLogged
        {
            get => _userLogged;
            set => SetProperty(ref  _userLogged, value);
        }

        public string UserTypeText
        {
            get => _userTypeText;
            set => SetProperty(ref _userTypeText, value);
        }

        public VMAppShell (INavigation nav)
        {
            Navigation = nav;
            Init();
        }

        public void Init ()
        {
            MessagingCenter.Subscribe<MUserLogged>(this, "LoginSuccess", userData =>
            {
                UserLogged = userData;
                UserTypeText = userData.userType ? "Administrador(a)" : "Emplead@";
            });
        }

        private async Task LogOut()
        {
            Application.Current.Properties.Clear();
            await Shell.Current.GoToAsync("//LoginView");
        }

        public ICommand LogOutCommand => new Command(async() => await LogOut());
    }
}
