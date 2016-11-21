using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MainApp.ViewModels;
using MainApp.Authentication;
using frontend.Service;
using frontend.Domain;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
using Windows.UI.Xaml;
    {
        private ICargoService cargoService;
        private IEmployeeService employeeService;
        private IExceedingsPerCargoService exceedingsService;
        private ILogService logService;
        private ISensorDataService sensorDataService;
        private ISensorService sensorService;
        private IVariableService variableService;
        
        [TestInitialize]
        public void Init()
        {
            cargoService = new CargoService(LoggedUser.Name, LoggedUser.Password);
            employeeService = new EmployeeService(LoggedUser.Name, LoggedUser.Password);
            exceedingsService = new ExceedingsPerCargoService(LoggedUser.Name, LoggedUser.Password);
            logService = new LogService(LoggedUser.Name, LoggedUser.Password);
            sensorDataService = new SensorDataService(LoggedUser.Name, LoggedUser.Password);
            sensorService = new SensorService(LoggedUser.Name, LoggedUser.Password);
            variableService = new VariableService(LoggedUser.Name, LoggedUser.Password);
            
        }
        [TestMethod]
        public void TestCargoViewModel()
        {
            var viewmodel = new CargoViewModel(cargoService, sensorService);
            ObservableCollection<Cargo> expectedData = new ObservableCollection<Cargo>(cargoService.All());
            var actualData = viewmodel.Cargos;
            Assert.AreSame(expectedData, actualData);
        }
        [TestMethod]
        public void TestEmployeeViewModel()
        {
            var viewmodel = new DriverViewModel(employeeService);
            ObservableCollection<Employee> expectedData = new ObservableCollection<Employee>(employeeService.All());
            var actualData = viewmodel.Drivers;
            Assert.AreSame(expectedData, actualData);
        }
        [TestMethod]
        public void TestExceedingViewModel()
        {
            var viewmodel = new ExceedingsViewModel(exceedingsService);
            ObservableCollection<ExceedingPerCargo> expectedData = new ObservableCollection<ExceedingPerCargo>(exceedingsService.All());
            var actualData = viewmodel.Exceedings;
            Assert.AreSame(expectedData, actualData);
        }
        [TestMethod]
        public void TestLogViewModel()
        {
            var viewmodel = new LogViewModel(logService);
            ObservableCollection<Log> expectedData = new ObservableCollection<Log>(logService.All());
            var actualData = viewmodel.Logs;
            Assert.AreSame(expectedData, actualData);
        }
       
        [TestMethod]
        public void TestSensorViewModel()
        {
            var viewmodel = new SensorViewModel(sensorService);
            ObservableCollection<Sensor> expectedData = new ObservableCollection<Sensor>(sensorService.All());
            var actualData = viewmodel.Sensors;
            Assert.AreSame(expectedData, actualData);
        }
        [TestMethod]
        public void TestVariableViewModel()
        {
            var viewmodel = new VariableViewModel(variableService);
            ObservableCollection<Variable> expectedData = new ObservableCollection<Variable>(variableService.All());
            var actualData = viewmodel.Variables;
            Assert.AreSame(expectedData, actualData);           
        }
        [TestMethod]
        public void TestAddCargoViewModel()
        {
            var viewmodel = new AddCargoViewModel(cargoService, sensorService);
            Cargo dummy = new Cargo();
            viewmodel.CurrentCargo = dummy;
            viewmodel.AddCargo(null);
            Assert.IsTrue(cargoService.All().Contains(dummy));
        }
        [TestMethod]
        public void TestAddDriverViewModel()
        {
            var viewmodel = new AddDriverViewModel(employeeService);
            Employee dummy = new Employee();
            viewmodel.CurrentDriver = dummy;
            viewmodel.AddDriver(null);
            Assert.IsTrue(employeeService.All().Contains(dummy));
        }
        [TestMethod]
        public void TestAddSensorViewModel()
        {
            var viewmodel = new AddSensorViewModel(sensorService);
            Sensor dummy = new Sensor();
            viewmodel.CurrentSensor = dummy;
            viewmodel.AddSensor(null);
            Assert.IsTrue(sensorService.All().Contains(dummy));
        }
        
    }
}
