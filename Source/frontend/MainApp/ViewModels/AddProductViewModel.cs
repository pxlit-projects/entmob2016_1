using frontend.Domain;
using frontend.Service;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class AddProductViewModel : INotifyPropertyChanged
    {
        private IProductService service;

        
        private List<string> statusList;

      
        private string selectedStatus;
        private Product currentProduct;
        

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddProductViewModel(IProductService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

       
        

        public List<string> StatusList
        {
            get
            {
                return statusList;
            }
            set
            {
                statusList = value;
                RaisePropertyChanged("StatusList");
            }
        }

       

        public string SelectedStatus
        {
            get
            {
                return selectedStatus;
            }
            set
            {
                selectedStatus = value;
                RaisePropertyChanged("SelectedStatus");
            }
        }

        public Product CurrentProduct
        {
            get
            {
                return currentProduct;
            }
            set
            {
                currentProduct = value;
                RaisePropertyChanged("CurrentProduct");
            }
        }

        

        private void LoadData()
        {
          

            StatusList = new List<string>
            {
                "true",
                "false"
            };

            CurrentProduct = new Product();
            
        }

        private void LoadCommands()
        {
            AddCommand = new RelayCommand<ContentDialog>(AddProduct, CanAddProduct);
        }

        private bool CanAddProduct(object obj)
        {
            return CurrentProduct != null;
        }

        private void AddProduct(ContentDialog dialog)
        {
            try
            {

                currentProduct.status = Boolean.Parse(selectedStatus);

                service.Add(CurrentProduct);
                dialog.Title = "Succesfull!";
                dialog.Hide();
            }
            catch (Exception)
            {
                dialog.Title = "Error! Please try again";
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}

