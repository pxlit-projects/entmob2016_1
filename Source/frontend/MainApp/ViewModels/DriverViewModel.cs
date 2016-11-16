﻿using frontend.Domain;
using frontend.Service;
using MainApp.Authentication;
using MainApp.Messages;
using MainApp.Navigation;
using MainApp.Utility;
using MainApp.Views;
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

namespace MainApp.ViewModels
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
            Messenger.Default.Register<Employee>(this, HandleDriverMessage);
            
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
            var dummy = service.All().OrderBy(d => d.Employee_id);
            Drivers = new ObservableCollection<Employee>(dummy);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, null);
            ChangeStatusCommand = new CustomCommand(ChangeStatus, null);
            ShowDriverDialogCommand = new CustomCommand(ShowDriverDialog, null);
        }

        private void HandleDriverMessage(Employee employee)
        {
            if (employee != null)
            {
                Employee lastEmployee = service.All().LastOrDefault();
                if (Drivers.LastOrDefault().Employee_id != lastEmployee.Employee_id)
                {
                    Drivers.Add(lastEmployee);
                }
            }
        }

        private void Update(object obj)
        {
            service.Update(SelectedDriver);
            LoadData();
        }

        private async void ChangeStatus(object obj)
        {
            if (SelectedDriver.Status == true)
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
                    SelectedDriver.Status = false;
                    service.Update(SelectedDriver);
                    LoadData();
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
                    SelectedDriver.Status = true;
                    service.Update(SelectedDriver);
                    LoadData();
                }
            }
        }

        public void ShowDriverDialog(object obj)
        {
            new NavService().NavigateTo("AddDriver");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
