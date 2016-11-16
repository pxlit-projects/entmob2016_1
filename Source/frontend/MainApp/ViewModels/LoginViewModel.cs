using frontend.Domain;
using frontend.Service;
using MainApp.Authentication;
using MainApp.Messages;
using MainApp.Navigation;
using MainApp.Utility;
using MainApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Employee currentEmployee;

        private IEmployeeService service;

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IEmployeeService service)
        {
            this.service = service;
            LoadCommands();
            currentEmployee = new Employee();
        }

        public void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, null);
        }

        private bool CanLogin(object obj)
        {
            return (CurrentEmployee.Password != null && CurrentEmployee.Username != null);
        }

        private void Login(object obj)
        {
            Employee employee = service.FindByUsername(CurrentEmployee.Username);
            string hashedPassword = PasswordHandler.Md5Encrypt(CurrentEmployee.Password, employee.Salt);
            if (hashedPassword == employee.Password)
            {
                LoggedUser.Employee_id = employee.Employee_id;
                LoggedUser.Name = employee.Name;
                LoggedUser.Salt = employee.Salt;
                LoggedUser.Status = employee.Status;
                LoggedUser.SurName = employee.SurName;

                new NavService().NavigateTo("Main");
            }
        }

        public Employee CurrentEmployee
        {
            get
            {
                return currentEmployee;
            }
            set
            {
                currentEmployee = value;
                RaisePropertyChanged("CurrentEmployee");
            }


        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

    }
}
