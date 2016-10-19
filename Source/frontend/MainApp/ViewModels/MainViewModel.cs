using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand HomeCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand SensorCommand { get; set; }
        public ICommand DriverCommand { get; set; }

        public MainViewModel()
        {

            LoadCommands();
        }

        public void NavigateHome(object obj)
        {

        }

        public void NavigateProduct(object obj)
        {

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

        }


    }
}
