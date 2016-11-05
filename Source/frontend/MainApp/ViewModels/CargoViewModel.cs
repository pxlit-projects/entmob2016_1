using frontend.Domain;
using frontend.Service;
using MainApp.Authentication;
using MainApp.Messages;
using MainApp.Navigation;
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
using Windows.UI.Xaml.Navigation;

namespace MainApp.ViewModels
{
    public class CargoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Cargo> cargos;
        private Cargo selectedCargo;

        public ICommand UpdateCommand { get; set; }
        public ICommand DetailsCommand { get; set; }
        public ICommand ShowCargoDialogCommand { get; set; }

        private ICargoService cargoService;
        private ISensorService sensorService;

        public CargoViewModel(ICargoService cargoService, ISensorService sensorService)
        {
            this.cargoService = cargoService;
            this.sensorService = sensorService;
            LoadData();
            LoadCommands();
            Messenger.Default.Register<Cargo>(this, HandleCargoMessage);
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
            var dummy = cargoService.All().OrderBy(d => d.Cargo_id);
            Cargos = new ObservableCollection<Cargo>(dummy);
            SelectedCargo = cargos.ElementAt(0);
        }

        private void HandleCargoMessage(Cargo cargo)
        {
            if (cargo != null)
            {
                Cargo lastCargo = cargoService.All().LastOrDefault();
                if (Cargos.LastOrDefault().Cargo_id != lastCargo.Cargo_id)
                {
                    Cargos.Add(lastCargo);
                }
            }
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdate);
            DetailsCommand = new CustomCommand(ShowDetails, null);
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
            cargoService.Update(SelectedCargo);
            LoadData();
        }

        public void ShowDetails(object obj)
        {
            Messenger.Default.Send(SelectedCargo);
            new NavService().NavigateTo("CargoDetails");
        }

        public void ShowCargoDialog(object obj)
        {
            new NavService().NavigateTo("AddCargo");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}

