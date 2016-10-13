using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void OnLoginClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await DisplayAlert("Clicked", usernameEntry.Text + " " + passwordEntry.Text,"OK");
        }
    }
}
