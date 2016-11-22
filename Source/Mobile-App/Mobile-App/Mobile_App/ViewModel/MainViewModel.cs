using frontend.Domain;
using frontend.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile_App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //  private IMD5 _md5;
        private INavigationService navService;
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
        public MainViewModel(INavigationService navigationService)
        {
            //_md5 = md5;
            this.navService = navigationService;
            InitializeCommands();
        }
        private void InitializeCommands() {
            LoginCommand = new Command(() =>
            {
                
                Debug.WriteLine(username + " " + password);
                IEmployeeService empService = new EmployeeService(Username,Password);

                Employee emp = empService.FindByUsername(username);
                if (emp != null)
                {
                    if (emp.Password == Password)
                    {
                        navService.PushAsync("ConnectSensor");
                        Messenger.Default.Send<Services.VariableMessage>(new Services.VariableMessage() {employee = emp});
                    }
                    else
                    {
                        Debug.WriteLine("Password Wrong");
                    }
                }
                else {
                    Debug.WriteLine("Username Wrong");
                }
                
                navService.PushAsync("ConnectSensor");
            });

        }
    }
}