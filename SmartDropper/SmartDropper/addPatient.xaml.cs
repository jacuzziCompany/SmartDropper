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
    public partial class addPatient : ContentPage
    {
        public addPatient()
        {
            InitializeComponent();
        }

        private async void createButton_clicked(object sender, EventArgs e)
        {
            try
            {
                Post post = new Post()
                {
                    Name = nameEntry.Text,
                    Surname = surnameEntry.Text,
                    Diagnose = diagnoseEntry.Text,
                    NumOfSmth = 5

                };
                bool result = Firestore.Insert(post);
                if (result)
                {
                    nameEntry.Text = String.Empty;
                    surnameEntry.Text = String.Empty;
                    diagnoseEntry.Text = String.Empty;
                    await DisplayAlert("success", "saved", "ok");

                    await Navigation.PushAsync(new Patient());
                }
                else
                    await DisplayAlert("Failure", "not saved", "ok");

            }
            catch(NullReferenceException nrex)
            {

            }
        }
        private async void backButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

    }
}