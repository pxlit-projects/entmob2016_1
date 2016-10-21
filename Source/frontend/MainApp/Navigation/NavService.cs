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
            SplitView  rootsplitview;
            
        

            switch (key)
            {
                case "Drivers":
                    DriversPage driversView = new DriversPage();
                    rootsplitview = new MainPage().GetSplitview();
                    rootsplitview.IsPaneOpen = false;
                    if (rootsplitview.Content != null)
                    {
                        ((Frame)rootsplitview.Content).Navigate(typeof(DriversPage));
                    }

                    break;
                    
                case "Products":
                    ProductsPage productsView = new ProductsPage();
                    rootsplitview = new MainPage().GetSplitview();
                    rootsplitview.IsPaneOpen = false;
                    if (rootsplitview.Content != null)
                    {
                        ((Frame)rootsplitview.Content).Navigate(typeof(ProductsPage));
                    }
                    break;
                case "Sensors":
                    SensorsPage sensorsView = new SensorsPage();
                    rootsplitview = new MainPage().GetSplitview();
                    rootsplitview.IsPaneOpen = false;
                    if (rootsplitview.Content != null)
                    {
                        ((Frame)rootsplitview.Content).Navigate(typeof(SensorsPage));
                    }
                    break;
                default:
                    rootsplitview = new MainPage().GetSplitview();
                    rootsplitview.IsPaneOpen = false;
                    if (rootsplitview.Content != null)
                    {
                        ((Frame)rootsplitview.Content).Navigate(typeof(MainPage));
                    }

                    break;
            }

        }
    }
}
