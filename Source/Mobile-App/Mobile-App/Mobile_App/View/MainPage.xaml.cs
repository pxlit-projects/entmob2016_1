using Autofac;
using JoesBurgerStore;
using Mobile_App.ViewModel;
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
        private readonly MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = AppContainer.Container.Resolve<MainViewModel>();
            this.BindingContext = viewModel;
        }
    }
}
