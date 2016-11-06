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
        public ICommand SensorCommand { get; set; }
        public ICommand DriverCommand { get; set; }
        public ICommand CargoCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand VariableCommand { get; set; }
        public ICommand ExceedingsCommand { get; set; }
        public ICommand LogCommand { get; set; }

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

        public void NavigateVariable(object obj)
        {
            new NavService().NavigateTo("Variables");
        }

        public void NavigateHome(object obj)
        {
            new NavService().NavigateTo("Home");
        }

        public void NavigateSensor(object obj)
        {
            new NavService().NavigateTo("Sensors");
        }

        public void NavigateDriver(object obj)
        {
            new NavService().NavigateTo("Drivers");
        }

        public void LoadCommands()
        {
            HomeCommand = new CustomCommand(NavigateHome, null);
            CargoCommand = new CustomCommand(NavigateCargo, null);
            SensorCommand = new CustomCommand(NavigateSensor, null);
            DriverCommand = new CustomCommand(NavigateDriver, null);
            MenuCommand = new RelayCommand<RadioButton>(ShowHideMenu, null);
            VariableCommand = new CustomCommand(NavigateVariable, null);
            ExceedingsCommand = new CustomCommand(NavigateExceeding, null);
            LogCommand = new CustomCommand(NavigateLog, null);
        }

        private void NavigateCargo(object obj)
        {
            new NavService().NavigateTo("Cargos");
        }

        private void NavigateExceeding(object obj)
        {
            new NavService().NavigateTo("Exceedings");
        }

        private void NavigateLog(object obj)
        {
            new NavService().NavigateTo("Logs");
        }
    }
}
