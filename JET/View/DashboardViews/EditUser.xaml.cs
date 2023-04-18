﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JET.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JET.View.DashboardViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUser : ContentPage
    {
        public EditUser()
        {
            InitializeComponent();
            BindingContext = new VMEditUser(Navigation);
        }
    }
}