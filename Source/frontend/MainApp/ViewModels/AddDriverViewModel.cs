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

namespace MainApp.ViewModels
{
    public class AddDriverViewModel
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
            AddCommand = new CustomCommand(AddDriver, null);
        }

        private void AddDriver(object obj)
        {
            try
            {


                service.Add(CurrentDriver);

                //if (statusBox.SelectedItem.ToString() == "Active")
                //{
                //    employee.status = true;
                //}
                //else
                //{
                //    employee.status = false;
                //}

                //service.Add(employee);
                //this.Title = "Succesfull!";
                //this.Hide();
            }
            catch (Exception)
            {
                //this.Title = "Error! Please try again";
            }

        }

        private Boolean checkBoxes()
        {
            //if (surNameBox.Text != null && nameBox.Text != null && emailBox.Text != null &&
            //    streetBox.Text != null && houseNrBox.Text != null && cityBox.Text != null &&
            //    postalAddressBox != null && dateEmployementBox.Date.DateTime != null && mobileBox.Text != null &&
            //    telephoneBox.Text != null && sexBox.SelectedItem != null && statusBox.SelectedItem != null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
