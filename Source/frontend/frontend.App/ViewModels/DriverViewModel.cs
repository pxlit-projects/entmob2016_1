using frontend.Appl.Utility;
using frontend.Appl.Views;
using frontend.Domain;
using frontend.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace frontend.Appl.ViewModels
{
    public class DriverViewModel : INotifyPropertyChanged
    {
        
        private ObservableCollection<Employee> drivers;
        private Employee selectedDriver;

        public ICommand UpdateCommand { get; set; }
        public ICommand ChangeStatusCommand { get; set; }
        public ICommand ShowDriverDialogCommand { get; set; }

        private IEmployeeService service;

        public DriverViewModel(IEmployeeService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

        public ObservableCollection<Employee> Drivers
        {
            get
            {
                return drivers;
            }
            set
            {
                drivers = value;
                RaisePropertyChanged("Drivers");
            }
        }

        public Employee SelectedDriver
        {
            get
            {
                return selectedDriver;
            }
            set
            {
                selectedDriver = value;
                RaisePropertyChanged("SelectedDriver");
            }
        }

        private void LoadData()
        {
            var dummy = service.All().OrderBy(d => d.employee_id);
            Drivers = new ObservableCollection<Employee>(dummy);
            SelectedDriver = drivers.ElementAt(0);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdate);
            ChangeStatusCommand = new CustomCommand(ChangeStatus, CanChangeStatus);
            ShowDriverDialogCommand = new CustomCommand(ShowDriverDialog, null);
        }

        private bool CanUpdate(object obj)
        {
            return SelectedDriver != null;
        }

        private bool CanChangeStatus(object obj)
        {
            return SelectedDriver != null;
        }

        private void Update(object obj)
        {
            service.Update(SelectedDriver);
        }

        private async void ChangeStatus(object obj)
        {
            if (SelectedDriver.status == true)
            {
                MessageDialog message = new MessageDialog("Are you sure you want to deactivate this driver?");
                message.Title = "Deactivate driver";
                var yesCommand = new UICommand("Yes") { Id = 0 };
                var noCommand = new UICommand("No") { Id = 1 };
                message.Commands.Add(yesCommand);
                message.Commands.Add(noCommand);

                message.DefaultCommandIndex = 0;
                message.CancelCommandIndex = 1;

                var result = await message.ShowAsync();

                if (result == yesCommand)
                {
                    SelectedDriver.status = false;
                    service.Update(SelectedDriver);
                }
            }
            else
            {
                MessageDialog message = new MessageDialog("Are you sure you want to activate this driver?");
                message.Title = "Activate driver";
                var yesCommand = new UICommand("Yes") { Id = 0 };
                var noCommand = new UICommand("No") { Id = 1 };
                message.Commands.Add(yesCommand);
                message.Commands.Add(noCommand);

                message.DefaultCommandIndex = 0;
                message.CancelCommandIndex = 1;

                var result = await message.ShowAsync();

                if (result == yesCommand)
                {
                    SelectedDriver.status = true;
                    service.Update(SelectedDriver);
                }
            }
        }

        private async void ShowDriverDialog(object obj)
        {
            var driverdialog = new AddDriverDialog();
            var result = await driverdialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                LoadData();
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
