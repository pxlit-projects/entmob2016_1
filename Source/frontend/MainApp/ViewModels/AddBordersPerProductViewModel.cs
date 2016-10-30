using frontend.Domain;
using frontend.Service;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class AddBordersPerProductViewModel : INotifyPropertyChanged
    {
        private IBordersPerProductService service;
        private IProductService productService;
        private IVariableService variableService;
        private int counter = 0;

        
        private Product selectedproduct;
        private Variable selectedvariable;
        private ObservableCollection<Product> products;
        private ObservableCollection<Variable> variables;

        private BorderPerProduct currentBordersPerProduct;

        private List<BorderPerProduct> bppList = new List<BorderPerProduct>();


        public ICommand DoneCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public AddBordersPerProductViewModel(IBordersPerProductService service, IProductService productservice, IVariableService variableservice)
        {
            this.service = service;
            variableService = variableservice;
            productService = productservice;
            LoadData();
            LoadCommands();
        }

        public Product SelectedProduct
        {
            get { return selectedproduct; }
            set { selectedproduct = value; RaisePropertyChanged("SelectedProduct"); }
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; RaisePropertyChanged("Products"); }
        }

        public Variable SelectedVariable
        {
            get { return selectedvariable; }
            set { selectedvariable = value; RaisePropertyChanged("SelectedVariable"); }
        }

        public ObservableCollection<Variable> Variables
        {
            get { return variables; }
            set { variables = value; RaisePropertyChanged("Variables"); }
        }
        public BorderPerProduct CurrentBordersPerProduct
        {
            get
            {
                return currentBordersPerProduct;
            }
            set
            {
                currentBordersPerProduct = value;
                RaisePropertyChanged("CurrentBordersPerProduct");
            }
        }

        public int Counter
        {
            get { return counter; }
            set { counter = value; RaisePropertyChanged("Counter"); }
        }

        private void LoadData()
        {
            var dummy = productService.All().OrderBy(d => d.Product_id);
            Products = new ObservableCollection<Product>(dummy);
            SelectedProduct = products.ElementAt(0);

            var dummyy = variableService.All().OrderBy(d => d.Variable_id);
            Variables = new ObservableCollection<Variable>(dummyy);
            SelectedVariable = variables.ElementAt(0);

            CurrentBordersPerProduct = new BorderPerProduct();
        }

        private void LoadCommands()
        {
            DoneCommand = new RelayCommand<ContentDialog>(Done, null);
            SaveCommand = new CustomCommand(AddBorderPerProduct, CanAddBorderPerProduct);
        }

        private bool CanAddBorderPerProduct(object obj)
        {
            return CurrentBordersPerProduct != null;
        }

        private void AddBorderPerProduct(object obj)
        {
            
            CurrentBordersPerProduct.Product = productService.Find(SelectedProduct.Product_id);
            CurrentBordersPerProduct.Variable = variableService.Find(SelectedVariable.Variable_id);
            CurrentBordersPerProduct.Id = new BorderPerProductPK() { Variable_id = SelectedVariable.Variable_id, Product_id = SelectedProduct.Product_id };

            bppList.Add(CurrentBordersPerProduct);
            counter += 1;  
        }

        private async void Done(ContentDialog dialog)
        {
            try
            {
                foreach (var bp in bppList)
                {
                    service.Add(bp);
                }
                MessageDialog msg = new MessageDialog("Succesfully added all borders");
                await msg.ShowAsync();
                dialog.Hide();
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog("Unsuccesfull because of :" + ex.Message.ToString());
                await msg.ShowAsync();
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
