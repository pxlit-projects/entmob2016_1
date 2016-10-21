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
            var frame = (Frame)Window.Current.Content;
            var page = (MainPage)frame.Content;





            switch (key)
            {
                case "Drivers":
                    DriversPage driversView = new DriversPage();
                    page.getFrame().Navigate(typeof(DriversPage));
                    break;
                    
                case "Products":
                    ProductsPage productsView = new ProductsPage();
                    page.getFrame().Navigate(typeof(ProductsPage));
                    break;

                case "Sensors":
                    SensorsPage sensorsView = new SensorsPage();
                    page.getFrame().Navigate(typeof(SensorsPage));
                    break;
                
                default:
                    HomePage homeView = new HomePage();
                    page.getFrame().Navigate(typeof(HomePage));
                    break;
            }

        }
    }
}
