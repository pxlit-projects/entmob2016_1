using MainApp.Navigation;
using MainApp.Utility;
using MainApp.Views;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System;

namespace MainApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand HomeCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand SensorCommand { get; set; }
        public ICommand DriverCommand { get; set; }

        public ICommand CargoCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand CityCommand { get; set; }

        public ICommand BordersPerProductCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand DestinationCommand { get; set; }

        public MainViewModel()
        {
            
            LoadCommands();
        }
        
        public void ShowHideMenu(RadioButton obj)
        {
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;
            page.splitview().IsPaneOpen = !page.splitview().IsPaneOpen;
            obj.IsChecked = false;

        }

        public void NavigateHome(object obj)
        {
            new NavService().NavigateTo("Home");
        }

        public void NavigateProduct(object obj)
        {
            new NavService().NavigateTo("Products");
        }

        public void NavigateSensor(object obj)
        {
            new NavService().NavigateTo("Sensors");
        }

        public void NavigateDriver(object obj)
        {
            new NavService().NavigateTo("Drivers");
        }

        public void NavigateDestination(object obj)
        {
            new NavService().NavigateTo("Destination");
        }

        public void LoadCommands()
        {
            HomeCommand = new CustomCommand(NavigateHome, null);
            LoginCommand = new CustomCommand(NavigateLogin, null);
            CargoCommand = new CustomCommand(NavigateCargo, null);
            CityCommand = new CustomCommand(NavigateCity, null);
            BordersPerProductCommand = new CustomCommand(NavigateBordersPerProduct, null);
            ProductCommand = new CustomCommand(NavigateProduct, null);
            SensorCommand = new CustomCommand(NavigateSensor, null);
            DriverCommand = new CustomCommand(NavigateDriver, null);
            MenuCommand = new RelayCommand<RadioButton>(ShowHideMenu, null);
            DestinationCommand = new CustomCommand(NavigateDestination, null);
            


        }

        private void NavigateBordersPerProduct(object obj)
        {
            new NavService().NavigateTo("BordersPerProduct");
        }

        private void NavigateCity(object obj)
        {
            new NavService().NavigateTo("City");
        }

        private void NavigateCargo(object obj)
        {
            new NavService().NavigateTo("Cargo");
        }

        private void NavigateLogin(object obj)
        {
            new NavService().NavigateTo("Login");
        }
    }
}
