using frontend.Domain;
using frontend.Service;
using MainApp.Messages;
using MainApp.Navigation;
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
    public class CargoDetailsViewModel : INotifyPropertyChanged
    {
        private Cargo currentCargo;
        private CargoBorder selectedBorder;
        private ICargoService cargoService;

        public ICommand AddBorderCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public CargoDetailsViewModel(ICargoService cargoService)
        {
            this.cargoService = cargoService;
            Messenger.Default.Register<Cargo>(this, LoadCargo);
            LoadCommands();
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(UpdateBorder, null);
            AddBorderCommand = new CustomCommand(ShowAddBorderPage, null);
        }

        private void LoadCargo(Cargo cargo)
        {
            CurrentCargo = cargo;
        }

        private void HandleCargoBorderMessage(CargoBorder cargoBorder)
        {
            CargoBorder border = cargoService.Find(cargoBorder.Cargo.Cargo_id).Borders.FirstOrDefault(b => b.Cargo_border_id == cargoBorder.Cargo_border_id);
            CurrentCargo.Borders.Add(border);
        }

        public void UpdateBorder(object obj)
        {
            if (SelectedBorder != null)
            {
                CurrentCargo.Borders.Where(b => b.Cargo_border_id == SelectedBorder.Cargo_border_id).ToList().ForEach(b => b = SelectedBorder);
                cargoService.Update(CurrentCargo);
                new NavService().NavigateTo("Cargos");
            }
        }

        public void ShowAddBorderPage(object obj)
        {
            Messenger.Default.Send(CurrentCargo);
            new NavService().NavigateTo("AddCargoBorder");
        }

        public Cargo CurrentCargo
        {
            get
            {
                return currentCargo;
            }
            set
            {
                currentCargo = value;
                RaisePropertyChanged("CurrentCargo");
            }
        }

        public CargoBorder SelectedBorder
        {
            get
            {
                return selectedBorder;
            }
            set
            {
                selectedBorder = value;
                RaisePropertyChanged("SelectedBorder");
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
