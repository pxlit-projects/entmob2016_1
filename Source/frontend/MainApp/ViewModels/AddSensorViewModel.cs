﻿using frontend.Domain;
using frontend.Service;
using MainApp.Authentication;
using MainApp.Messages;
using MainApp.Navigation;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class AddSensorViewModel : INotifyPropertyChanged
    {
        private ISensorService service;

        private List<string> statusList;

        private string selectedStatus;
        private Sensor currentSensor;

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddSensorViewModel(ISensorService service)
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

        public Sensor CurrentSensor
        {
            get
            {
                return currentSensor;
            }
            set
            {
                currentSensor = value;
                RaisePropertyChanged("CurrentSensor");
            }
        }



        private void LoadData()
        {
            StatusList = new List<string>
            {
                "Active",
                "Non-active"
            };

            CurrentSensor = new Sensor();
        }

        private void LoadCommands()
        {
            AddCommand = new CustomCommand(AddSensor, CanAddSensor);
        }

        private bool CanAddSensor(object obj)
        {
            return CurrentSensor != null;
        }

        private void AddSensor(Object obj)
        {
            if (SelectedStatus == "Active")
            {
                CurrentSensor.Status = true;
            }
            else
            {
                CurrentSensor.Status = false;
            }

            service.Add(CurrentSensor);
            Messenger.Default.Send(CurrentSensor);
            new NavService().NavigateTo("Sensors");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}

