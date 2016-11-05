using frontend.Domain;
using frontend.Service;
using MainApp.Navigation;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainApp.ViewModels
{
    public class LoginViewModel
    {
        private Employee currentEmployee;

        private IEmployeeService service;

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IEmployeeService service)
        {
            this.service = service;
            LoadCommands();
        }

        public void LoadCommands()
        {
            LoginCommand = new CustomCommand(Login, null);
        }

        private bool CanLogin(object obj)
        {
            return CurrentEmployee != null;
        }

        private void Login(object obj)
        {
            //Employee employee = service.FindByUsername(CurrentEmployee.Username);
            //string hashedPassword = PasswordHandler.Md5Encrypt(CurrentEmployee.Password, employee.Salt);
            //if (hashedPassword == employee.Password)
            //{
                new NavService().NavigateTo("Main");
            //}
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
            }
        }
    }
}
