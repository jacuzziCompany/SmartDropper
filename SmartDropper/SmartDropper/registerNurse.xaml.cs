﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartDropper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registerNurse : ContentPage
    {
        public registerNurse()
        {
            InitializeComponent();
        }

        private async void secondSignUpButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }
    }
}