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
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class SensorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ISensorService service; 
        private ObservableCollection<Sensor> sensors;

        public ICommand UpdateCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand ShowDialogCommand { get; set; }

        public SensorViewModel(ISensorService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
            Messenger.Default.Register<Sensor>(this, HandleSensorMessage);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, null);
            ChangeStatusCommand = new CustomCommand(ChangeStatus, null);
            ShowDialogCommand = new CustomCommand(ShowDialog, null);
        }

        private void LoadData()
        {
            var sensorsList = service.All().OrderBy(d => d.Sensor_id);
            Sensors = new ObservableCollection<Sensor>(sensorsList);
        }

        private void HandleSensorMessage(Sensor sensor)
        {
            if (sensor != null)
            {
                Sensor lastSensor = service.All().LastOrDefault();
                Sensor lastSensorFromList = Sensors.LastOrDefault();
                if (lastSensorFromList != null)
                {
                    if (lastSensorFromList.Sensor_id != lastSensor.Sensor_id)
                    {
                        Sensors.Add(lastSensor);
                    }
                }
                else
                {
                    Sensors.Add(lastSensor);
                }
                
            }
        }

        public void Update(object obj)
        {
            service.Update(SelectedSensor);
            LoadData();
        }

        public void ChangeStatus(object obj)
        {
            service.ChangeStatus(SelectedSensor);
            LoadData();
        }

        public void ShowDialog(object obj)
        {
            new NavService().NavigateTo("AddSensor");
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
