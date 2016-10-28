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
                    page.getFrame().Navigate(typeof(DriversPage));
                    break;                  
                case "Products":                  
                    page.getFrame().Navigate(typeof(ProductsPage));
                    break;
                case "Sensors":                    
                    page.getFrame().Navigate(typeof(SensorsPage));
                    break;
                case "City":                  
                    page.getFrame().Navigate(typeof(CitiesPage));
                    break;
                case "Cargo":                    
                    page.getFrame().Navigate(typeof(CargosPage));
                    break;
                case "Login":
                    page.getFrame().Navigate(typeof(LoginsPage));
                    break;
                case "BordersPerProduct":
                    page.getFrame().Navigate(typeof(BordersPerProductPage));
                    break;
                case "Destination":
                    page.getFrame().Navigate(typeof(DestinationsPage));
                    break;
                case "Variable":
                    page.getFrame().Navigate(typeof(VariablesPage));
                    break;
                default:
                    HomePage homeView = new HomePage();
                    page.getFrame().Navigate(typeof(HomePage));
                    break;
            }

        }
    }
}
