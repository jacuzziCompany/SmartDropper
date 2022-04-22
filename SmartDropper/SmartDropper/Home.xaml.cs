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
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void myProfileButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new myProfile());
        }

      
        private async void listOfPatientsButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listOfPAtients());
        }

        private async void addPatientButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addPatient());
        }

        private async void listOfMedicineButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listOfMedicine());
        }



    }

}