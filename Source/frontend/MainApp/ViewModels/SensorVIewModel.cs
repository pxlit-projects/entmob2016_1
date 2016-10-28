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
    public class SensorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ISensorService service = new SensorService();
        private ISensorUsageService usageService = new SensorUsageService();
        private ObservableCollection<Sensor> sensors;
        private ObservableCollection<SensorUsage> sensorUsages;


        public ICommand UpdateCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand ShowDialogCommand { get; set; }
        public ICommand ShowSensorUsageCommand { get; set; }
        public SensorViewModel(ISensorService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdateOrChangeStatus);
            ChangeStatusCommand = new CustomCommand(ChangeStatus, CanUpdateOrChangeStatus);
            ShowDialogCommand = new CustomCommand(ShowDialog, null);
            ShowSensorUsageCommand = new CustomCommand(ShowSensorUsage, null);
        }
        private void LoadData()
        {
            var sensorsList = service.All().OrderBy(d => d.Sensor_id);
            Sensors = new ObservableCollection<Sensor>(sensorsList);
            SelectedSensor = sensors.ElementAt(0);
        }

        public bool CanUpdateOrChangeStatus(object obj)
        {
            return SelectedSensor != null;
        }

        public void Update(object obj)
        {
            service.Update(SelectedSensor);
        }

        public void ChangeStatus(object obj)
        {
            service.ChangeStatus(SelectedSensor);
        }

        public async void ShowDialog(object obj)
        {
            var dialog = new AddSensorDialog();
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                LoadData();
            }
        }

        public void ShowSensorUsage(object obj)
        {
            var list = usageService.All().Where(d => d.Sensor.Sensor_id == SelectedSensor.Sensor_id);
            SensorUsages = new ObservableCollection<SensorUsage>(list);
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

        public ObservableCollection<SensorUsage> SensorUsages
        {
            get
            {
                return sensorUsages;
            }
            set
            {
                sensorUsages = value;
                RaisePropertyChanged("SensorUsages");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
