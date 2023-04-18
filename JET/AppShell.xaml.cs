using JET.View.DashboardViews;
using JET.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JET
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EditUser), typeof(EditUser));
            Routing.RegisterRoute(nameof(DeleteUser), typeof(DeleteUser));
            BindingContext = new VMAppShell(Navigation);
        }
    }
}