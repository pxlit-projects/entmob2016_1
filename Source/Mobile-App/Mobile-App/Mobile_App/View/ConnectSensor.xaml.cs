using Autofac;
using JoesBurgerStore;
using Mobile_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

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
