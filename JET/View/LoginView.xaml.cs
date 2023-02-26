using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JET.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JET.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new VMLogin(Navigation);
        }
    }
}