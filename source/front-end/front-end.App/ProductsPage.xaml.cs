using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using front_end.Domain;
using front_end.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SplitViewDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            this.InitializeComponent();
            init( );
        }

        private void init() {
            IProductService service = new ProductService( );
            List<Product> products = service.All( );
            productsList.DataContext = products;
        }

        private void productsList_SelectionChanged( object sender, SelectionChangedEventArgs e ) {
            this.DataContext = ( ( Product ) productsList.SelectedItem );
        }
    }
}
