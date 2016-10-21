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
    public class CargoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Cargo> cargos;
        private Cargo selectedCargo;

        public ICommand UpdateCommand { get; set; }
        public ICommand DetailsCommand { get; set; }
        public ICommand ShowCargoDialogCommand { get; set; }

        private ICargoService service;

        public CargoViewModel(ICargoService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

        public ObservableCollection<Cargo> Cargos
        {
            get
            {
                return cargos;
            }
            set
            {
                cargos = value;
                RaisePropertyChanged("Cargos");
            }
        }

        public Cargo SelectedCargo
        {
            get
            {
                return selectedCargo;
            }
            set
            {
                selectedCargo = value;
                RaisePropertyChanged("SelectedCargo");
            }
        }

        private void LoadData()
        {
            var dummy = service.All().OrderBy(d => d.cargo_id);
            Cargos = new ObservableCollection<Cargo>(dummy);
            SelectedCargo = cargos.ElementAt(0);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdate);
            DetailsCommand = new RelayCommand<MessageDialog>(ShowDetails, null);
            ShowCargoDialogCommand = new CustomCommand(ShowCargoDialog, null);
        }

        private bool CanUpdate(object obj)
        {
            return SelectedCargo != null;
        }

        private bool CanChangeStatus(object obj)
        {
            return SelectedCargo != null;
        }

        private void Update(object obj)
        {
            service.Update(SelectedCargo);
            LoadData();
        }

        public void ShowDetails(MessageDialog message)
        {

        }


        public async void ShowCargoDialog(object obj)
        {
            //var dialog = new AddCargoDialog();
            //var result = await dialog.ShowAsync();
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

