using front_end.Domain;
using front_end.Services;
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
        public void OnLoginClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //await DisplayAlert("Clicked", usernameEntry.Text + " " + passwordEntry.Text,"OK");
            String username = usernameEntry.Text;
            String password = passwordEntry.Text;

            var logService = new LoginService();
            var empService = new EmployeeService();
            //var emp = user.FindByUsername(username);
            var emp = new Employee();


        }
        /*   public static string Md5Encrypt(string original)
           {
               byte[] encodedBytes;

               using (var md5 = new MD5CryptoServiceProvider())
               {
                   var originalBytes = Encoding.Default.GetBytes(original);
                   encodedBytes = md5.ComputeHash(originalBytes);
               }

               return Convert.ToBase64String(encodedBytes);
           }
       */
    }
}
