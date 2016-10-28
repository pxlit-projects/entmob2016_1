using frontend.Domain;
using frontend.Service;
using MainApp.Utility;
using MainApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class DestinationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<City> cities;
        private ObservableCollection<Destination> destinations;
        private City selectedCity;
        private Destination selectedDestination;

        public ICommand UpdateCommand { get; set; }
        public ICommand AddDestinationCommand { get; set; }
        public ICommand ChangeCityCommand { get; set; }
        public ICommand ShowCitiesCommand { get; set; }

        private ICityService cityService;
        private IDestinationService destinationService;

        public DestinationViewModel(ICityService service, IDestinationService servicee)
        {
            this.cityService = service;
            this.destinationService = servicee;
            LoadData();
            LoadCommands();
        }

        public ObservableCollection<City> Cities
        {
            get
            {
                return cities;
            }
            set
            {
                cities = value;
                RaisePropertyChanged("Cities");
            }
        }

        public City SelectedCity
        {
            get
            {
                return selectedCity;
            }
            set
            {
                selectedCity = value;
                RaisePropertyChanged("SelectedCity");
            }
        }

        public ObservableCollection<Destination> Destinations
        {
            get
            {
                return destinations;
            }
            set
            {
                destinations = value;
                RaisePropertyChanged("Destinations");
            }
        }

        public Destination SelectedDestination
        {
            get
            {
                return selectedDestination;
            }
            set
            {
                selectedDestination = value;
                RaisePropertyChanged("SelectedDestination");
            }
        }

        private void LoadData()
        {
            var dummy = destinationService.All().OrderBy(d => d.Destination_id);
            Destinations = new ObservableCollection<Destination>(dummy);
            SelectedDestination = destinations.ElementAt(0);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdate);

            ShowCitiesCommand = new CustomCommand(ShowCities, null);

            AddDestinationCommand = new CustomCommand(AddDestination, null);

            ChangeCityCommand = new CustomCommand(ChangeCity, CanUpdateCity);
        }

        private bool CanUpdate(object obj)
        {
            return SelectedDestination != null;
        }
        private bool CanUpdateCity (object obj) {
            return SelectedCity != null;
        }



        private void Update(object obj)
        {
            destinationService.Update(SelectedDestination);
            LoadData();
        }


        private async void AddDestination(object obj)
        {
            var dialog = new AddDestinationDialog();
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                LoadData();
            }
        }

        private void ChangeCity (object obj)
        {
            SelectedDestination.City = SelectedCity;
            destinationService.Update(SelectedDestination);
            LoadData();
        }
        public void ShowCities(object obj)
        {
            var dummy = cityService.All().OrderBy(d => d.Postal_code);
            Cities = new ObservableCollection<City>(dummy);
            selectedCity = cities.ElementAt(0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
