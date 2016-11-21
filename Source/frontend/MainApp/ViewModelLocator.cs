using frontend.Service;
using MainApp.Authentication;
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
        #region Services
        private static ISensorService sensorService = new SensorService(LoggedUser.Username, LoggedUser.Password);
        private static IEmployeeService employeeService = new EmployeeService(LoggedUser.Username, LoggedUser.Password);
        private static ICargoService cargoService = new CargoService(LoggedUser.Username, LoggedUser.Password);
        private static ICargoBorderService cargoBorderService = new CargoBorderService(LoggedUser.Username, LoggedUser.Password);
        private static IVariableService variableService = new VariableService(LoggedUser.Username, LoggedUser.Password);
        private static IExceedingsPerCargoService exceedingsService = new ExceedingsPerCargoService(LoggedUser.Username, LoggedUser.Password);
        private static ILogService logService = new LogService(LoggedUser.Username, LoggedUser.Password);
        #endregion

        #region Views
        private SensorViewModel sensorViewModel = new SensorViewModel(sensorService);
        private DriverViewModel driverViewModel = new DriverViewModel(employeeService);
        private MainViewModel mainViewModel = new MainViewModel();
        private CargoViewModel cargoViewModel = new CargoViewModel(cargoService, sensorService);
        private VariableViewModel variableViewModel = new VariableViewModel(variableService);
        private LoginViewModel loginViewModel = new LoginViewModel(employeeService);
        private CargoDetailsViewModel cargoDetailsViewModel = new CargoDetailsViewModel(cargoService);
        private ExceedingsViewModel exceedingsViewModel = new ExceedingsViewModel(exceedingsService);
        private LogViewModel logViewModel = new LogViewModel(logService);
        private AddCargoViewModel addCargoViewModel = new AddCargoViewModel(cargoService, sensorService);
        private AddCargoBorderViewModel addCargoBorderViewModel = new AddCargoBorderViewModel(cargoService, variableService, cargoBorderService);
        private AddDriverViewModel addDriverViewModel = new AddDriverViewModel(employeeService);
        private AddSensorViewModel addSensorViewModel = new AddSensorViewModel(sensorService);
        #endregion

        #region Properties
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

        public AddCargoViewModel AddCargoViewModel
        {
            get
            {
                return addCargoViewModel;
            }
        }

        public AddCargoBorderViewModel AddCargoBorderViewModel
        {
            get
            {
                return addCargoBorderViewModel;
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return loginViewModel;
            }
        }

        public CargoDetailsViewModel CargoDetailsViewModel
        {
            get
            {
                return cargoDetailsViewModel;
            }
        }

        public ExceedingsViewModel ExceedingsViewModel
        {
            get
            {
                return exceedingsViewModel;
            }
        }

        public LogViewModel LogViewModel
        {
            get
            {
                return logViewModel;
            }
        }
        #endregion
    }
}
