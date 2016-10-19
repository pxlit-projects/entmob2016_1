using frontend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Appl.ViewModels;

namespace frontend.Appl
{
    public class ViewModelLocator
    {
        private static ISensorService sensorService = new SensorService();
        private static IProductService productService = new ProductService();
        private static IEmployeeService employeeService = new EmployeeService();
        

        private static SensorViewModel sensorViewModel = new SensorViewModel(sensorService);
        private static ProductViewModel productViewModel = new ProductViewModel(productService);
        private static DriverViewModel driverViewModel = new DriverViewModel(employeeService);
        private static MainViewModel mainViewModel = new MainViewModel();

        public static DriverViewModel DriverViewModel
        {
            get
            {
                return driverViewModel;
            }
        }

        public static ProductViewModel ProductViewModel
        {
            get
            {
                return productViewModel;
            }
        }

        public static SensorViewModel SensorViewModel
        {
            get
            {
                return sensorViewModel;
            }
        }

        public static MainViewModel MainViewModel
        {
            get
            {
                return mainViewModel;
            }
        }

    }
}
