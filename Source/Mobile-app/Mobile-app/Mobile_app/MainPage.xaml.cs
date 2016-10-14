using front_end.Domain;
using front_end.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile_app
{
    public partial class MainPage : ContentPage
    {
        IMD5 md5;
        public MainPage(IMD5 md5)
        {
            InitializeComponent();
            this.md5 = md5;
        }
        public async void OnLoginClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await DisplayAlert("Clicked", md5.Md5Encrypt("test"), "OK");
            String username = usernameEntry.Text;
            String password = passwordEntry.Text;

            var logService = new LoginService();
            var empService = new EmployeeService();
            //var emp = user.FindByUsername(username);
            var emp = new Employee();
            if (md5.Md5Encrypt(emp.salt + password) == emp.password)
            {
                //password correct
            }
            else {
                //password incorrect
                await DisplayAlert("Password Incorrect", "The Provided password is incorrect", "OK");
            }

        }
    }
}

