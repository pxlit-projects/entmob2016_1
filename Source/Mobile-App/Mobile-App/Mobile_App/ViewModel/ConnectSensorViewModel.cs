using frontend.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Java.Lang;
using JoesBurgerStore.Contracts;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile_App.ViewModel
{
    //TODO: RECIEVE LOGIN EMPLOYEE
    class ConnectSensorViewModel : ViewModelBase
    {

        private IAdapter adapter;
        private Employee employee;
        private ObservableCollection<IDevice> devicesList;
        private INavigationService navService;
        public ICommand SearchCommand { get; set; }
        public ICommand ConnectCommand { get; set; }
        private IDevice selectedDevice;

        public IDevice SelectedDevice
        {
            get
            {
                return selectedDevice;
            }
            set
            {
                if (selectedDevice != value)
                {
                    selectedDevice = value;
                    RaisePropertyChanged("SelectedDevice");
                    ConnectCommand.Execute(selectedDevice);
                }
            }
        }
        public ObservableCollection<IDevice> DeviceList
        {
            get
            {
                return devicesList;
            }
            set
            {
                devicesList = value;
                RaisePropertyChanged("DeviceList");
            }
        }

        public ConnectSensorViewModel(INavigationService navigationService)
        {
            this.adapter = App.GetAdapter();
            DeviceList = new ObservableCollection<IDevice>();
            this.navService = navigationService;
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) =>
            {
                    foreach (var item in devicesList)
                    {
                        if (item.ID == e.Device.ID)
                        {
                            return;
                        }
                    }
                    devicesList.Add(e.Device);
                    DeviceList = devicesList;
                
            };
            InitialiseCommands();
        }

        private void InitialiseCommands()
        {
            SearchCommand = new Command(() =>
            {
                StartScanning();
            });
            ConnectCommand = new Command(() =>
            {
                StopScanning();
                
                var device = SelectedDevice as IDevice;
                navService.PushAsync("HomeView");
                Messenger.Default.Send<Services.VariableMessage>(new Services.VariableMessage() { connectedDevice = device, adapter = this.adapter, employee=this.employee });
            });
        }
        void StartScanning()
        {
            StartScanning(Guid.Empty);
        }
        void StartScanning(Guid forService)
        {

            if (adapter.IsScanning)
            {
                adapter.StopScanningForDevices();
                Debug.WriteLine("StartScanning > adapter.StopScanningForDevices()");
            }
            else
            {
                devicesList.Clear();
                adapter.StartScanningForDevices(forService);
                Debug.WriteLine("adapter.StartScanningForDevices(" + forService + ")");
            }
        }
        void StopScanning()
        {
            // stop scanning
            new Task(() =>
            {
                if (adapter.IsScanning)
                {
                    Debug.WriteLine("Still scanning, stopping the scan");
                    adapter.StopScanningForDevices();
                }
            }).Start();
        }
        void UpdateDisplay(ICharacteristic c)
        {
            Debug.WriteLine(c.StringValue);
        }
    }

}
