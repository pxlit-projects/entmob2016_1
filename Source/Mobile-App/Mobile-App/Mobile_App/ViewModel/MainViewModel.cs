using front_end.Services;
using GalaSoft.MvvmLight;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile_App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
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
        public MainViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands() {
            LoginCommand = new Command(() =>
            {
                Debug.WriteLine(username + " " + password);
                IEmployeeService empService = new EmployeeService();
                ILoginService logService = new LoginService();
                
            });
        }
    }
}