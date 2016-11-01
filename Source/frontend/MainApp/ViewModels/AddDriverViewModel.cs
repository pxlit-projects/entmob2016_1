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
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class AddDriverViewModel : INotifyPropertyChanged
    {
        private IEmployeeService service;
        
        private List<string> statusList;
        
        private string selectedStatus;
        private Employee currentDriver;

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddDriverViewModel(IEmployeeService service)
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

        public Employee CurrentDriver
        {
            get
            {
                return currentDriver;
            }
            set
            {
                currentDriver = value;
                RaisePropertyChanged("CurrentDriver");
            }
        }

        private void LoadData()
        {
            StatusList = new List<string>
            {
                "Active",
                "Non-active"
            };

            CurrentDriver = new Employee();
        }

        private void LoadCommands()
        {
            AddCommand = new RelayCommand<ContentDialog>(AddDriver, CanAddDriver);
        }

        private bool CanAddDriver(object obj)
        {
            return CurrentDriver != null;
        }

        private void AddDriver(ContentDialog dialog)
        {
            try
            {
                if (SelectedStatus == "Active")
                {
                    CurrentDriver.Status = true;
                }
                else
                {
                    CurrentDriver.Status = false;
                }

                service.Add(CurrentDriver);
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
