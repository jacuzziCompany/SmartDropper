using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDropper.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartDropper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
        }
        public async void secondLoginButton_clicked(object sender, EventArgs e)

        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            if (isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                bool result = await Auth.LoginUser(emailEntry.Text, passwordEntry.Text);
                if (result)
                    await Navigation.PushAsync(new Home());
                
               
            }


           
        }
        private async void backButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new firstPage());
        }

        private async void signUp_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new registerNurse());
        }
    }
}