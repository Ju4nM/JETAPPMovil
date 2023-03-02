using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JET.View;

namespace JET
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new LoginView());
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
