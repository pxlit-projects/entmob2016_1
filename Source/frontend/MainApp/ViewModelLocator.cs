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


        private SensorViewModel sensorViewModel = new SensorViewModel(sensorService);
        private ProductViewModel productViewModel = new ProductViewModel(productService);
        private DriverViewModel driverViewModel = new DriverViewModel(employeeService);
        private AddDriverViewModel addDriverViewModel = new AddDriverViewModel(employeeService);

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
    }
}
