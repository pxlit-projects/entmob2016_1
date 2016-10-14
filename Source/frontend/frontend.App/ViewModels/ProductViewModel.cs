using frontend.App.Utility;
using frontend.Domain;
using frontend.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace frontend.App.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IProductService service = new ProductService();
        public ICommand UpdateCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand ShowDialogCommand { get; set; }
        private ObservableCollection<Product> products;

        public ProductViewModel(IProductService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
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
        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdateOrChangeStatus);
            ChangeStatusCommand = new CustomCommand(ChangeStatus, CanUpdateOrChangeStatus);
            ShowDialogCommand = new CustomCommand(ShowDialog, null);
           
        }
        public bool CanUpdateOrChangeStatus(object obj)
        {
            return SelectedProduct != null;
        }
        public void Update(object obj)
        {
            service.Update(SelectedProduct);
        }

        public void ChangeStatus(object obj)
        {
            service.ChangeStatus(SelectedProduct);
        }

        public void ShowDialog(object obj)
        {

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
