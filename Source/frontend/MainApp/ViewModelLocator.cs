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
        private static IProductService productService = new ProductService();
        private static IEmployeeService employeeService = new EmployeeService();
        private static ICargoService cargoService = new CargoService();
        private static ILoginService loginService = new LoginService();
        private static ICityService cityService = new CityService();
        private static IBordersPerProductService bordersPerProductService = new BordersPerProductService();
        private static IDestinationService destinationService = new DestinationService();
        


        private SensorViewModel sensorViewModel = new SensorViewModel(sensorService);
        private ProductViewModel productViewModel = new ProductViewModel(productService);
        private DriverViewModel driverViewModel = new DriverViewModel(employeeService);
        private AddDriverViewModel addDriverViewModel = new AddDriverViewModel(employeeService);
        private MainViewModel mainViewModel = new MainViewModel();
        private CargoViewModel cargoViewModel = new CargoViewModel(cargoService);
        private LoginViewModel loginViewModel = new LoginViewModel(loginService);
        private CityViewModel cityViewModel = new CityViewModel(cityService);
        private BordersPerProductViewModel bordersPerProductViewModel = new BordersPerProductViewModel(bordersPerProductService);
        private DestinationViewModel destinationViewModel = new DestinationViewModel(cityService, destinationService);
        private AddDestinationViewModel addDestinationViewModel = new AddDestinationViewModel(destinationService);

        public DriverViewModel DriverViewModel
        {
            get
            {
                return driverViewModel;
            }
        }

        public ProductViewModel ProductViewModel
        {
            get
            {
                return productViewModel;
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

        public CityViewModel CityViewModel
        {
            get
            {
                return cityViewModel;
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return loginViewModel;
            }
        }

        public BordersPerProductViewModel BordersPerProductViewModel
        {
            get
            {
                return bordersPerProductViewModel;
            }
        }

        public DestinationViewModel DestinationViewModel
        {
            get
            {
                return destinationViewModel;
            }
        }

        public AddDestinationViewModel AddDestinationViewModel
        {
            get
            {
                return addDestinationViewModel;
            }
        }

    }
}
