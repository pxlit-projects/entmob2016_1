using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MainApp.ViewModels;
using MainApp.Authentication;
using frontend.Service;
using frontend.Domain;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Windows.UI.Xaml;
using System;
using MainApp.Utility;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        private ICargoService cargoService;
        private ICargoBorderService cargoBorderService;
        private IEmployeeService employeeService;
        private IExceedingsPerCargoService exceedingsService;
        private ILogService logService;
        private ISensorDataService sensorDataService;
        private ISensorService sensorService;
        private IVariableService variableService;
        
        [TestInitialize]
        public void Init()
        {
            cargoService = new CargoService(LoggedUser.Username, LoggedUser.Password);
            cargoBorderService = new CargoBorderService(LoggedUser.Username, LoggedUser.Password);
            employeeService = new EmployeeService(LoggedUser.Username, LoggedUser.Password);
            exceedingsService = new ExceedingsPerCargoService(LoggedUser.Username, LoggedUser.Password);
            logService = new LogService(LoggedUser.Username, LoggedUser.Password);
            sensorDataService = new SensorDataService(LoggedUser.Username, LoggedUser.Password);
            sensorService = new SensorService(LoggedUser.Username, LoggedUser.Password);
            variableService = new VariableService(LoggedUser.Username, LoggedUser.Password);
        }

        [TestMethod]
        public void TestLogViewModel()
        {
            var viewmodel = new LogViewModel(logService);

            ObservableCollection<Log> expectedData = new ObservableCollection<Log>(logService.All());

            Assert.AreEqual(expectedData.Count, viewmodel.Logs.Count);
        }

        // TODO : Er moet één cargo bestaan in de database met id = 1;
        [TestMethod]
        public void TestCargoViewModel()
        {
            var viewmodel = new CargoViewModel(cargoService, sensorService);

            ObservableCollection<Cargo> expectedData = new ObservableCollection<Cargo>(cargoService.All());
            var cargo = cargoService.Find(1);
            viewmodel.SelectedCargo = cargo;

            Assert.AreEqual(expectedData.Count, viewmodel.Cargos.Count);
            Assert.IsNotNull(viewmodel.SelectedCargo);
            Assert.AreEqual(1, viewmodel.SelectedCargo.Cargo_id);
        }

        // TODO : Er moet één employee bestaan in de database met id = 1 en Role = ROLE_ADMIN
        [TestMethod]
        public void TestEmployeeViewModel()
        {
            var viewmodel = new DriverViewModel(employeeService);
            
            ObservableCollection<Employee> expectedData = new ObservableCollection<Employee>(employeeService.All());
            var driver = employeeService.Find(1);
            viewmodel.SelectedDriver = driver;

            Assert.AreEqual(expectedData.Count, viewmodel.Drivers.Count);
            Assert.IsNotNull(viewmodel.SelectedDriver);
            Assert.AreEqual(Role.ROLE_ADMIN, viewmodel.SelectedDriver.Clearance);
        }

        // TODO : Er moet één exceeding bestaan in de database met id = 1
        [TestMethod]
        public void TestExceedingViewModel()
        {
            var viewmodel = new ExceedingsViewModel(exceedingsService);

            ObservableCollection<ExceedingPerCargo> expectedData = new ObservableCollection<ExceedingPerCargo>(exceedingsService.All());
            var exceeding = exceedingsService.Find(1);
            viewmodel.SelectedExceeding = exceeding;

            Assert.AreEqual(expectedData.Count, viewmodel.Exceedings.Count);
            Assert.IsNotNull(viewmodel.SelectedExceeding);
            Assert.AreEqual(1, viewmodel.SelectedExceeding.Exceeding_per_cargo_id);
        }

        // TODO : Er moet één sensor bestaan in de database met id = 1
        [TestMethod]
        public void TestSensorViewModel()
        {
            var viewmodel = new SensorViewModel(sensorService);

            ObservableCollection<Sensor> expectedData = new ObservableCollection<Sensor>(sensorService.All());
            var sensor = sensorService.Find(1);
            viewmodel.SelectedSensor = sensor;

            Assert.AreEqual(expectedData.Count, viewmodel.Sensors.Count);
            Assert.IsNotNull(viewmodel.SelectedSensor);
            Assert.AreEqual(1, viewmodel.SelectedSensor.Sensor_id);
        }

        [TestMethod]
        public void TestVariableViewModel()
        {
            var viewmodel = new VariableViewModel(variableService);

            ObservableCollection<Variable> expectedData = new ObservableCollection<Variable>(variableService.All());

            var variable = variableService.Find(1);
            viewmodel.SelectedVariable = variable;

            Assert.AreEqual(expectedData.Count, viewmodel.Variables.Count);
            Assert.IsNotNull(viewmodel.SelectedVariable);
            Assert.AreEqual(1, viewmodel.SelectedVariable.Variable_id);
        }

        [TestMethod]
        public void TestAddCargoViewModel()
        {
            var viewmodel = new AddCargoViewModel(cargoService, sensorService);
            int previousCargoCounter = cargoService.All().Count;

            viewmodel.SelectedSensor = "1";

            try
            {
                viewmodel.AddCargo(null);
            }
            catch (NullReferenceException)
            {
                // Navigation error
            }
            
            int expectedCargoCounter = previousCargoCounter + 1;

            Assert.IsNotNull(viewmodel.CurrentCargo);
            Assert.IsTrue(viewmodel.SensorList.Contains(viewmodel.SelectedSensor));
            Assert.IsTrue(expectedCargoCounter == cargoService.All().Count);
        }

        [TestMethod]
        public void TestAddDriverViewModel()
        {
            var viewmodel = new AddDriverViewModel(employeeService);

            int previousEmployeeCounter = employeeService.All().Count;

            viewmodel.SelectedStatus = "Active";

            // Aanmaken van een unieke username
            viewmodel.CurrentDriver.Username = "Gebruiker" + logService.All().Count;

            viewmodel.CurrentDriver.Name = "Test";
            viewmodel.CurrentDriver.SurName = "Gebruiker";
            viewmodel.CurrentDriver.Password = "test123";

            try
            {
                viewmodel.AddDriver(null);
            }
            catch (NullReferenceException)
            {
                // Navigation error
            }

            int expectedEmployeeCounter = previousEmployeeCounter + 1;
            var addedEmployee = employeeService.FindByUsername(viewmodel.CurrentDriver.Username);

            Assert.IsNotNull(viewmodel.CurrentDriver);
            Assert.AreEqual(viewmodel.CurrentDriver.Clearance, Role.ROLE_ADMIN);
            Assert.IsTrue(viewmodel.StatusList.Contains("Active"));
            Assert.IsTrue(expectedEmployeeCounter == employeeService.All().Count);
            Assert.AreEqual(viewmodel.CurrentDriver.Password, PasswordHandler.Md5Encrypt("test123", addedEmployee.Salt));
        }

        [TestMethod]
        public void TestAddSensorViewModel()
        {
            var viewmodel = new AddSensorViewModel(sensorService);

            int previousSensorCounter = sensorService.All().Count;

            viewmodel.SelectedStatus = "Active";
            viewmodel.CurrentSensor.Sensor_name = "SensorTag " + logService.All().Count;

            try
            {
                viewmodel.AddSensor(null);
            }
            catch (NullReferenceException)
            {
                // Navigation error
            }

            int expectedSensorCounter = previousSensorCounter + 1;

            Assert.IsNotNull(viewmodel.CurrentSensor);
            Assert.IsTrue(viewmodel.StatusList.Contains(viewmodel.SelectedStatus));
            Assert.IsTrue(expectedSensorCounter == sensorService.All().Count);
        }

        // TODO : Er moet één variable bestaan in de database met description = Temperatuur
        [TestMethod]
        public void TestAddCargoBorderViewModel()
        {
            var viewmodel = new AddCargoBorderViewModel(cargoService, variableService, cargoBorderService);

            int previousCargoBorderCounter = cargoBorderService.All().Count;

            viewmodel.SelectedCargo = cargoService.Find(1);
            viewmodel.SelectedVariable = "Temperatuur";
            viewmodel.CurrentCargoBorder.Value = logService.All().Count;

            try
            {
                viewmodel.AddBorder(null);
            }
            catch (NullReferenceException)
            {
                // Navigation error
            }

            int expectedCargoBorderCounter = previousCargoBorderCounter + 1;

            Assert.IsNotNull(viewmodel.SelectedCargo);
            Assert.IsNotNull(viewmodel.CurrentCargoBorder);
            Assert.IsTrue(viewmodel.VariableList.Contains(viewmodel.SelectedVariable));
            Assert.IsTrue(expectedCargoBorderCounter == cargoBorderService.All().Count);
        }
    }
}
