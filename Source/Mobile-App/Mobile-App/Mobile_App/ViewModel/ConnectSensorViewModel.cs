using GalaSoft.MvvmLight;
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
    class ConnectSensorViewModel: ViewModelBase
    {
        
        private IAdapter adapter;
        private ObservableCollection<IDevice> devicesList;
        private INavigationService navService;
        public ICommand SearchCommand { get; set; }
        public ICommand ConnectCommand { get; set; }
        private IDevice selectedDevice;
        private ObservableCollection<IService> services;

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

        public ConnectSensorViewModel(INavigationService navigationService) {
            this.adapter = App.GetAdapter();
            DeviceList = new ObservableCollection<IDevice>();
            this.navService = navigationService;
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) => {
                Device.BeginInvokeOnMainThread(() => {
                    if (!DeviceList.Contains(e.Device)) {
                        devicesList.Add(e.Device);
                        DeviceList = devicesList;
                    }
                });
            };
            InitialiseCommands();
        }

        private void InitialiseCommands()
        {
            SearchCommand = new Command(() => {
                StartScanning();
            });
            ConnectCommand = new Command(() =>
            {
                StopScanning();
                this.services = new ObservableCollection<IService>();
                var device = SelectedDevice as IDevice;
                Debug.WriteLine(adapter.ConnectedDevices.Count);
                adapter.ConnectToDevice(device);
                adapter.DeviceConnected += (s, e) => {
                    device = e.Device; // do we need to overwrite this?
                    // when services are discovered
                    device.ServicesDiscovered += (object se, EventArgs ea) => {
                        Debug.WriteLine("device.ServicesDiscovered");
                        //services = (List<IService>)device.Services;
                        if (services.Count == 0)
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                foreach (var service in device.Services)
                                {
                                    services.Add(service);
                                    foreach (var item in service.Characteristics)
                                    {
                                        item.StartUpdates();
                                        Debug.WriteLine("OUTPUT: " + item.StringValue);
                                        item.StopUpdates();
                                    }
                                }
                            });
                    };
                    // start looking for services
                    device.DiscoverServices();
                };
            });
        }

        private void DisplayCharactaristic(ICharacteristic characteristic)
        {
            if (characteristic.CanUpdate)
            {
                characteristic.ValueUpdated += (s, e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        //UpdateDisplay(characteristic);
                        Debug.WriteLine(s.ToString());
                        if (characteristic.CanRead)
                        {
                            var c = await characteristic.ReadAsync();
                            UpdateDisplay(c);
                        }
                    });
                };
                characteristic.StartUpdates();
            }
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
            new Task(() => {
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
