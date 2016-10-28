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

        private List<string> sexList;
        private List<string> statusList;

        private string selectedSex;
        private string selectedStatus;
        private Employee currentDriver;
        private City currentCity;

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddDriverViewModel(IEmployeeService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

        public List<string> SexList
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

        public City CurrentCity
        {
            get
            {
                return currentCity;
            }
            set
            {
                currentCity = value;
                RaisePropertyChanged("CurrentCity");
            }
        }

        private void LoadData()
        {
            SexList = new List<string>
            {
                "Male",
                "Female"
            };

            StatusList = new List<string>
            {
                "Active",
                "Non-active"
            };

            CurrentDriver = new Employee();
            CurrentCity = new City();
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
                CurrentDriver.Sex = SelectedSex;
                CurrentDriver.City = CurrentCity;
                CurrentDriver.Date_employement = new DateTime(1996, 1, 2).ToString();

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
