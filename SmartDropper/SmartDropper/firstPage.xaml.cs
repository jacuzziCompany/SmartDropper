using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartDropper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class firstPage : ContentPage
    {
        public firstPage()
        {
            InitializeComponent();
        }

        private async void loginButton_clicked(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new login());
        }

        private async void signUpButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registerNurse());
        }

    }
}