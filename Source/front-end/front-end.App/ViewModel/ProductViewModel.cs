using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using front_end.Domain;
using front_end.Services;
using System.Collections.ObjectModel;

namespace front_end.App.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IProductService service = new ProductService();

        private ObservableCollection<Product> products;

        public ProductViewModel (IProductService service)
        {
            this.service = service;
            LoadData();
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                RaisePropertyChanged("Products");
            }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        private void LoadData()
        {
            var productslist = service.All().OrderBy(d => d.product_id);
            Products = new ObservableCollection<Product>(productslist);
            SelectedProduct = products.ElementAt(0);
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
