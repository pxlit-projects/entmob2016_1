using frontend.Domain;
using frontend.Service;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class AddDestinationViewModel : INotifyPropertyChanged
    {
        private IDestinationService service;

        
        private Destination currentDestination;
        private City currentCity;

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddDestinationViewModel(IDestinationService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

  

     

        public Destination CurrentDestination
        {
            get
            {
                return currentDestination;
            }
            set
            {
                currentDestination = value;
                RaisePropertyChanged("CurrentDestination");
            }
        }

        public City CurrentCity
        {
            get
            {
                return currentCity;
            }
            set
            {
                currentCity = value;
                RaisePropertyChanged("CurrentCity");
            }
        }

        private void LoadData()
        {
           
            CurrentDestination = new Destination();
            CurrentCity = new City();
        }

        private void LoadCommands()
        {
            AddCommand = new RelayCommand<ContentDialog>(AddDriver, CanAddDestination);
        }

        private bool CanAddDestination(object obj)
        {
            return CurrentDestination != null;
        }

        private void AddDriver(ContentDialog dialog)
        {
            try
            {
                
                CurrentDestination.City = CurrentCity;

               

                service.Add(CurrentDestination);
                dialog.Title = "Succesfull!";
                dialog.Hide();
            }
            catch (Exception)
            {
                dialog.Title = "Error! Please try again";
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
