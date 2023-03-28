using JET.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JET.View.DashboardViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notificaciones : ContentPage
    {
        public Notificaciones()
        {
            InitializeComponent();
            BindingContext = new VMNotificaciones(Navigation);
        }
    }
}