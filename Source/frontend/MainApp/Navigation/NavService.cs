using MainApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MainApp.Navigation
{
    public class NavService
    {
        public void NavigateTo(string key)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            
            switch (key)
            {
                case "Drivers":
                    DriversPage driversView = new DriversPage();
                    rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(DriversPage));
                    break;
                case "Products":
                    ProductsPage productsView = new ProductsPage();
                    rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(ProductsPage));
                    break;
                case "Sensors":
                    SensorsPage sensorsView = new SensorsPage();
                    rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(SensorsPage));
                    break;
                default:
                    HomePage homeView = new HomePage();
                    rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(HomePage));
                    break;
            }

        }
    }
}
