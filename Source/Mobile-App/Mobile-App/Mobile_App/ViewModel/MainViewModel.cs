using frontend.Domain;
using frontend.Service;
using GalaSoft.MvvmLight;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile_App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IMD5 _md5;
        private String username;
        public String Username {
            get {
                return username;
            }
            set {
                username = value;
                RaisePropertyChanged("Username");
            }
        }
        private String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }
        public ICommand LoginCommand { get; set; }
        public MainViewModel(IMD5 md5)
        {
            _md5 = md5;
            InitializeCommands();
        }
        private void InitializeCommands() {
            LoginCommand = new Command(() =>
            {
                Debug.WriteLine(username + " " + password);
                IEmployeeService empService = new EmployeeService();
                ILoginService logService = new LoginService();

                Employee emp = empService.FindByUsername(username);
                if (emp != null) {
                    if (emp.password == _md5.Md5Encrypt(emp.salt + password)) {
                        Debug.WriteLine("LOGIN");
                    }
                }
            });
        }
    }
}