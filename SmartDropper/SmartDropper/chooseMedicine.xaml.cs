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
    public partial class chooseMedicine : ContentPage
    {
        public chooseMedicine()
        {
            InitializeComponent();
        }

        private async void backButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Patient());
        }
    }
}