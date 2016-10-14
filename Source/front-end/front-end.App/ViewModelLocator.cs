using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_end.Services;
using front_end.App.ViewModel;

namespace front_end.App
{
    public class ViewModelLocator
    {
        private static ISensorService sensorService = new SensorService();
        private static IProductService productService = new ProductService();
        private static IEmployeeService employeeService = new EmployeeService();

        private static SensorViewModel SensorViewModel = new SensorViewModel(sensorService);
        private static ProductViewModel ProductViewModel = new ProductViewModel(productService);
        private static DriverViewModel DriverViewModel = new DriverViewModel(employeeService);


    }
}
