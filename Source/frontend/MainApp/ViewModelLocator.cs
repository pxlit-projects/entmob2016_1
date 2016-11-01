using frontend.Service;
using MainApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class ViewModelLocator
    {
        private static ISensorService sensorService = new SensorService();
        private static IEmployeeService employeeService = new EmployeeService();
        private static ICargoService cargoService = new CargoService();
        private static IVariableService variableService = new VariableService();

        // Page Views
        private SensorViewModel sensorViewModel = new SensorViewModel(sensorService);
        private DriverViewModel driverViewModel = new DriverViewModel(employeeService);
        private MainViewModel mainViewModel = new MainViewModel();
        private CargoViewModel cargoViewModel = new CargoViewModel(cargoService);
        private VariableViewModel variableViewModel = new VariableViewModel(variableService);
     
        // AddDialogs
        private AddDriverViewModel addDriverViewModel = new AddDriverViewModel(employeeService);
        private AddSensorViewModel addSensorViewModel = new AddSensorViewModel(sensorService);

        public DriverViewModel DriverViewModel
        {
            get
            {
                return driverViewModel;
            }
        }

        public SensorViewModel SensorViewModel
        {
            get
            {
                return sensorViewModel;
            }
        }

        public AddDriverViewModel AddDriverViewModel
        {
            get
            {
                return addDriverViewModel;
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return mainViewModel;
            }
        }

        public CargoViewModel CargoViewModel
        {
            get
            {
                return cargoViewModel;
            }
        }

        public VariableViewModel VariableViewModel
        {
            get
            {
                return variableViewModel;
            }
        }

        public AddSensorViewModel AddSensorViewModel
        {
            get
            {
                return addSensorViewModel;
            }
        }
    }
}
