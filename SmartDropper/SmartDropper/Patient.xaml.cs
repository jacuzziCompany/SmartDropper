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
    public partial class Patient : ContentPage
    {
        public Patient()
        {
            InitializeComponent();
        }

        private async void endTherapyButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new endTherapy());
        }
        private async void startTherapyButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new chooseMedicine());
        }
        private async void addMedicationButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addMedication());
        }
        private async void deletePatientButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new deletePatient());
        }

        private async void backButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

    }
}