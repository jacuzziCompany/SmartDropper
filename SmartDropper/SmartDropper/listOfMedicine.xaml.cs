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
    public partial class listOfMedicine : ContentPage
    {
        public listOfMedicine()
        {
            InitializeComponent();
        }

        private async void backButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

        private async void addMedicationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addMedication());
        }


    }
}