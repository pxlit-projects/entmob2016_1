
using Autofac;
using JoesBurgerStore;
using JoesBurgerStore.Contracts;
using Robotics.Mobile.Core.Bluetooth.LE;
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
        static IAdapter Adapter;
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
        public static void SetAdapter(IAdapter adapter)
        {
            Adapter = adapter;
        }
        public static IAdapter GetAdapter() {
            return Adapter;
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
