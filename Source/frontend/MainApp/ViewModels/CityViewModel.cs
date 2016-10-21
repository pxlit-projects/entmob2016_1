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
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class CityViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<City> cities;
        private City selectedCity;

        public ICommand UpdateCommand { get; set; }
        
        public ICommand ShowCityDialogCommand { get; set; }

        private ICityService service;

        public CityViewModel(ICityService service)
        {
            this.service = service;
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

        private void LoadData()
        {
            var dummy = service.All().OrderBy(d => d.postal_code);
            Cities = new ObservableCollection<City>(dummy);
            SelectedCity = cities.ElementAt(0);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdate);
            
            ShowCityDialogCommand = new CustomCommand(ShowCityDialog, null);
        }

        private bool CanUpdate(object obj)
        {
            return SelectedCity != null;
        }

        

        private void Update(object obj)
        {
            service.Update(SelectedCity);
            LoadData();
        }




        public async void ShowCityDialog(object obj)
        {
            //var dialog = new AddCityDialog();
            //var result = await driverdialog.ShowAsync();
            //if (result == ContentDialogResult.Primary)
            //{
            //    LoadData();
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
