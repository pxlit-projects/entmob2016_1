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

            if (key == "Main")
            {
                frame.Navigate(typeof(MainPage));
            }
            else
            {
                var page = (MainPage)frame.Content;

                switch (key)
                {
                    case "Drivers":
                        page.getFrame().Navigate(typeof(DriversPage));
                        break;
                    case "Sensors":
                        page.getFrame().Navigate(typeof(SensorsPage));
                        break;
                    case "Cargos":
                        page.getFrame().Navigate(typeof(CargosPage));
                        break;
                    case "Variables":
                        page.getFrame().Navigate(typeof(VariablesPage));
                        break;
                    case "AddDriver":
                        page.getFrame().Navigate(typeof(AddDriverPage));
                        break;
                    case "AddSensor":
                        page.getFrame().Navigate(typeof(AddSensorPage));
                        break;
                    case "AddCargo":
                        page.getFrame().Navigate(typeof(AddCargoPage));
                        break;
                    case "AddCargoBorder":
                        page.getFrame().Navigate(typeof(AddCargoBorderPage));
                        break;
                    case "CargoDetails":
                        page.getFrame().Navigate(typeof(CargoDetailsPage));
                        break;
                    case "Exceedings":
                        page.getFrame().Navigate(typeof(ExceedingsPage));
                        break;
                    case "Logs":
                        page.getFrame().Navigate(typeof(LogPage));
                        break;
                    default:
                        page.getFrame().Navigate(typeof(HomePage));
                        break;
                }
            }
        }
    }
}
