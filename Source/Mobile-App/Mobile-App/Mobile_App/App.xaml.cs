using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Mobile_App
{
    public partial class App : Application
    {
        public IMD5 md5;
        public App(IMD5 md5)
        {
            InitializeComponent();
            this.md5 = md5;
            MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
