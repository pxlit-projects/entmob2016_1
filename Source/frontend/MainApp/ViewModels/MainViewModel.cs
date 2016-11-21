using MainApp.Navigation;
using MainApp.Utility;
using MainApp.Views;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System;
using MainApp.Messages;
using frontend.Domain;
using MainApp.Authentication;

namespace MainApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        LoggedUser logged;
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
            Messenger.Default.Register<LoggedUser>(this, SaveLoggedUser);
            LoadCommands();
        }

        public void SaveLoggedUser(LoggedUser User)
        {
            if (User!=null)
            {
                logged = User;
            }
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
            Messenger.Default.Send<LoggedUser>(logged);
            new NavService().NavigateTo("Variables");
        }

        public void NavigateHome(object obj)
        {
            Messenger.Default.Send<LoggedUser>(logged);
            new NavService().NavigateTo("Home");
        }

        public void NavigateSensor(object obj)
        {
            Messenger.Default.Send<LoggedUser>(logged);
            new NavService().NavigateTo("Sensors");
        }

        public void NavigateDriver(object obj)
        {
            Messenger.Default.Send<LoggedUser>(logged);
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
            Messenger.Default.Send<LoggedUser>(logged);
            new NavService().NavigateTo("Cargos");
        }

        private void NavigateExceeding(object obj)
        {
            Messenger.Default.Send<LoggedUser>(logged);
            new NavService().NavigateTo("Exceedings");
        }

        private void NavigateLog(object obj)
        {
            Messenger.Default.Send<LoggedUser>(logged);
            new NavService().NavigateTo("Logs");
        }
    }
}
