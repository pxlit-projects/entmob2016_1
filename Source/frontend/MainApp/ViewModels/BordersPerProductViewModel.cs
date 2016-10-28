using frontend.Domain;
using frontend.Service;
using MainApp.Utility;
using MainApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class BordersPerProductViewModel : INotifyPropertyChanged
    {
        
        
            private ObservableCollection<BordersPerProduct> bordersPerProducts;
            private BordersPerProduct selectedBordersPerProduct;

            public ICommand UpdateCommand { get; set; }

            public ICommand AddCommand { get; set; }

            public ICommand ShowBordersPerProductDialogCommand { get; set; }

            private IBordersPerProductService service;

            public BordersPerProductViewModel(IBordersPerProductService service)
            {
                this.service = service;
                LoadData();
                LoadCommands();
            }

            public ObservableCollection<BordersPerProduct> BorderPerProducts
            {
                get
                {
                    return bordersPerProducts;
                }
                set
                {
                    bordersPerProducts = value;
                    RaisePropertyChanged("BorderPerProducts");
                }
            }

            public BordersPerProduct SelectedBordersPerProduct
            {
                get
                {
                    return selectedBordersPerProduct;
                }
                set
                {
                    selectedBordersPerProduct = value;
                    RaisePropertyChanged("SelectedBordersPerProduct");
                }
            }

            private void LoadData()
            {
                var dummy = service.All().OrderBy(d => d.Id);
                BorderPerProducts = new ObservableCollection<BordersPerProduct>(dummy);
                SelectedBordersPerProduct = bordersPerProducts.ElementAt(0);
            }

            private void LoadCommands()
            {
                UpdateCommand = new CustomCommand(Update, CanUpdate);
                AddCommand = new CustomCommand(AddBorders, null);
                ShowBordersPerProductDialogCommand = new CustomCommand(ShowBordersPerProductDialog, null);
            }

            private bool CanUpdate(object obj)
            {
                return SelectedBordersPerProduct != null;
            }
            
            


            private void Update(object obj)
            {
                service.Update(SelectedBordersPerProduct);
                LoadData();
            }

        public void ShowBordersPerProductDialog(object obj)
        {
            
        }


        public async void AddBorders(object obj)
        {
            var dialog = new AddBordersPerProductDialog();
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                LoadData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string v)
            {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        }
    }

