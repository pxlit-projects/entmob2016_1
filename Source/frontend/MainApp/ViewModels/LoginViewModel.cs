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
using Windows.UI.Popups;

namespace MainApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Login> logins;
        private Login selectedLogin;

        public ICommand UpdateCommand { get; set; }
        public ICommand DetailsCommand { get; set; }
        

        private ILoginService service;

        public LoginViewModel(ILoginService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

        public ObservableCollection<Login> Logins
        {
            get
            {
                return logins;
            }
            set
            {
                logins = value;
                RaisePropertyChanged("Logins");
            }
        }

        public Login SelectedLogin
        {
            get
            {
                return selectedLogin;
            }
            set
            {
                selectedLogin = value;
                RaisePropertyChanged("SelectedLogin");
            }
        }

        private void LoadData()
        {
            var dummy = service.All().OrderBy(d => d.Login_id);
            Logins = new ObservableCollection<Login>(dummy);
            SelectedLogin = logins.ElementAt(0);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdate);
            DetailsCommand = new RelayCommand<MessageDialog>(ShowDetails, null);
           
        }

        private bool CanUpdate(object obj)
        {
            return SelectedLogin != null;
        }

        private bool CanChangeStatus(object obj)
        {
            return SelectedLogin != null;
        }

        private void Update(object obj)
        {
            service.Update(SelectedLogin);
            LoadData();
        }

        public void ShowDetails(MessageDialog message)
        {

        }

       
              
    


    public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}

