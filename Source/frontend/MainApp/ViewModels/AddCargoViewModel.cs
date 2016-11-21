using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;
using frontend.Service;
using System.Windows.Input;
using MainApp.Utility;
using MainApp.Navigation;
using MainApp.Messages;
using System.Collections.ObjectModel;

namespace MainApp.ViewModels
{
    public class AddCargoViewModel : INotifyPropertyChanged
    {
        private List<string> sensorList;
        private string selectedSensor;
        private Cargo currentCargo;
        private ICargoService cargoService;
        private ISensorService sensorService;

        public ICommand AddCommand { get; set; }

        public AddCargoViewModel(ICargoService cargoService, ISensorService sensorService)
        {
            this.cargoService = cargoService;
            this.sensorService = sensorService;
            LoadCommands();
            LoadData();
        }

        public void LoadCommands()
        {
            AddCommand = new CustomCommand(AddCargo, null);
        }

        public void LoadData()
        {
            CurrentCargo = new Cargo();
            SensorList = new List<string>();
            List<Sensor> sensors = sensorService.All();
            sensors.ForEach(s => SensorList.Add(Convert.ToString(s.Sensor_id)));
        }

        public void AddCargo(object obj)
        {
            if (SelectedSensor != null)
            {
                CurrentCargo.Sensor_id = Convert.ToInt32(SelectedSensor);
                cargoService.Add(CurrentCargo);
                Messenger.Default.Send(CurrentCargo);
                new NavService().NavigateTo("Cargos");
            }
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

        public List<string> SensorList
        {
            get
            {
                return sensorList;
            }
            set
            {
                sensorList = value;
            }
        }

        public string SelectedSensor
        {
            get
            {
                return selectedSensor;
            }
            set
            {
                selectedSensor = value;
                RaisePropertyChanged("SelectedSensor");
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
