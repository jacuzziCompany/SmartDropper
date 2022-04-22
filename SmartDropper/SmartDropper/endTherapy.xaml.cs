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
    public partial class endTherapy : ContentPage
    {
        public endTherapy()
        {
            InitializeComponent();
        }

        private async void yesButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Patient());
        }

        private async void noButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Patient());
        }


    }
}