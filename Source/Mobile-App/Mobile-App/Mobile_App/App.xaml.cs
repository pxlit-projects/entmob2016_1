using Autofac;
using JoesBurgerStore;
using JoesBurgerStore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Mobile_App
{
    public partial class App : Application
    {
        private IMD5 md5;
        public App(IMD5 md5)
        {
            InitializeComponent();
            this.md5 = md5;
            AppContainer.Container = new Bootstrap().CreateContainer();
            var login = new MainPage();
            var navigationService = AppContainer.Container.Resolve<INavigationService>();
            navigationService.Navigation = login.Navigation;
            MainPage = new NavigationPage(login);
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
