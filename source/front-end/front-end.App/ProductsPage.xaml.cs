using System.Windows;
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
using Windows.UI.Popups;
using System;
using front_end.App;

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
        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            IProductService service = new ProductService();
            try
            {
                product.product_id = int.Parse(idTxt.Text);
                product.title = nameTxt.Text;
                product.description = descTxt.Text;
                service.Update(product);
            }
            catch (Exception)
            {
                MessageDialog message = new MessageDialog("You might have made a mistake in one of the textboxes.");
                message.Title = "Format Error";
                message.Commands.Clear();
                message.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                await message.ShowAsync();
            }

        }

        private void ChangeStatusButton_Click(Object sender, RoutedEventArgs e)
        {
            IProductService service = new ProductService();
            service.ChangeStatus((Product)productsList.SelectedItem);
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var productdialog = new AddProductDialog();
            var result = await productdialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                init();

            }
        }
    }
}
