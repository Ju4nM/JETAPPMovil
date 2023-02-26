using JET.View.DashboardViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JET.View.BurgerMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BurgerMenuFlyout : ContentPage
    {
        public ListView ListView;

        public BurgerMenuFlyout()
        {
            InitializeComponent();

            BindingContext = new BurgerMenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class BurgerMenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<BurgerMenuFlyoutMenuItem> MenuItems { get; set; }

            public BurgerMenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<BurgerMenuFlyoutMenuItem>(new[]
                {
                    new BurgerMenuFlyoutMenuItem { Id = 0, Title = "Acerca de", TargetType = typeof(AboutView) },
                    new BurgerMenuFlyoutMenuItem { Id = 1, Title = "Control", TargetType = typeof(ControlView) },
                    new BurgerMenuFlyoutMenuItem { Id = 2, Title = "Usuarios", TargetType = typeof(UserView) },
                    new BurgerMenuFlyoutMenuItem { Id = 3, Title = "Graficas", TargetType = typeof(ChartView) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}