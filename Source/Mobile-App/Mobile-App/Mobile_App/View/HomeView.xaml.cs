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
    public partial class HomeView : CarouselPage
    {
        private readonly HomeViewModel viewModel;
        public HomeView()
        {
            InitializeComponent();
            viewModel = AppContainer.Container.Resolve<ViewModel.HomeViewModel>();
            this.BindingContext = viewModel;
        }
    }
}
