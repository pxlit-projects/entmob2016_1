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

        private ObservableCollection<string> sexList;
        private ObservableCollection<string> statusList;

        private string selectedSex;
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

        public ObservableCollection<string> SexList
        {
            get
            {
                return sexList;
            }
            set
            {
                sexList = value;
                RaisePropertyChanged("SexList");
            }
        }

        public ObservableCollection<string> StatusList
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

        public string SelectedSex
        {
            get
            {
                return selectedSex;
            }
            set
            {
                selectedSex = value;
                RaisePropertyChanged("SelectedSex");
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
            SexList = new ObservableCollection<string>
            {
                "Male",
                "Female"
            };

            StatusList = new ObservableCollection<string>
            {
                "Active",
                "Non-active"
            };
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
                CurrentDriver.sex = SelectedSex;

                if (SelectedStatus == "Active")
                {
                    CurrentDriver.status = true;
                }
                else
                {
                    CurrentDriver.status = false;
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
