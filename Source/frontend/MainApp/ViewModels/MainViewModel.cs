using MainApp.Navigation;
using MainApp.Utility;
using MainApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using MainApp.Views;
using Windows.UI.Xaml;

namespace MainApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        

        public ICommand HomeCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand SensorCommand { get; set; }
        public ICommand DriverCommand { get; set; }

        public ICommand MenuCommand { get; set; }

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

        }

        public void NavigateDriver(object obj)
        {

        }

        public void LoadCommands()
        {
            HomeCommand = new CustomCommand(NavigateHome, null);
            ProductCommand = new CustomCommand(NavigateProduct, null);
            SensorCommand = new CustomCommand(NavigateSensor, null);
            DriverCommand = new CustomCommand(NavigateDriver, null);
            MenuCommand = new RelayCommand<RadioButton>(ShowHideMenu, null);


        }


    }
}
