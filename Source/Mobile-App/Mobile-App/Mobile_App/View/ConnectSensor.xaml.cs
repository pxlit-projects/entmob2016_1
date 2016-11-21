using Autofac;
using Mobile_App.Services;
using Robotics.Mobile.Core.Bluetooth.LE;
using Mobile_App.ViewModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System;

namespace Mobile_App.View
{
    public partial class ConnectSensor : ContentPage
    {
        private readonly ConnectSensorViewModel viewModel;

        public ConnectSensor()
        {
            InitializeComponent();
            viewModel = AppContainer.Container.Resolve<ConnectSensorViewModel>();
            this.BindingContext = viewModel;
        }
    }
}
