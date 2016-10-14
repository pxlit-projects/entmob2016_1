using front_end.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_end.Domain;
using System.Collections.ObjectModel;

namespace front_end.App.ViewModel
{
    public class SensorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ISensorService service = new SensorService();

        private ObservableCollection<Sensor> sensors;

        public SensorViewModel(ISensorService service)
        {
            this.service = service;
            LoadData();
        }

        private void LoadData()
        {
            var sensorsList = service.All().OrderBy(d => d.sensor_id);
            Sensors = new ObservableCollection<Sensor>(sensorsList);
            SelectedSensor = sensors.ElementAt(0);
        }

        public ObservableCollection<Sensor> Sensors
        {
            get
            {
                return sensors;
            }
            set
            {
                sensors = value;
                RaisePropertyChanged("Sensors");
            }
        }

        private Sensor selectedSensor;

        public Sensor SelectedSensor
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

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
