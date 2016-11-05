using frontend.Domain;
using frontend.Service;
using MainApp.Messages;
using MainApp.Navigation;
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
            AddCommand = new CustomCommand(AddDriver, null);
        }

        private void AddDriver(object obj)
        {
            if (SelectedStatus == "Active")
            {
                CurrentDriver.Status = true;
            }
            else
            {
                CurrentDriver.Status = false;
            }

            CurrentDriver.Salt = PasswordHandler.GenerateSalt();
            CurrentDriver.Password = PasswordHandler.Md5Encrypt(CurrentDriver.Password, CurrentDriver.Salt);

            service.Add(CurrentDriver);
            Messenger.Default.Send(CurrentDriver);
            new NavService().NavigateTo("Drivers");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
