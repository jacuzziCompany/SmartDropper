using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDropper.Helpers;
using SmartDropper.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartDropper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listOfPAtients : ContentPage
    {
        public listOfPAtients()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var posts = await Firestore.Read();
             
        }

        private async void backButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }
    }
}