﻿using frontend.Domain;
using frontend.Service;
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
    public class AddCityViewModel : INotifyPropertyChanged
    {
        private ICityService service;

       
        private City currentCity;
        

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddCityViewModel(ICityService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

        

        public City CurrentCity
        {
            get
            {
                return currentCity;
            }
            set
            {
                currentCity = value;
                RaisePropertyChanged("CurrentCity");
            }
        }

        private void LoadData()
        {
            

            
            CurrentCity = new City();
        }

        private void LoadCommands()
        {
            AddCommand = new RelayCommand<ContentDialog>(AddCity, CanAddCity);
        }

        private bool CanAddCity(object obj)
        {
            return CurrentCity != null;
        }

        private void AddCity(ContentDialog dialog)
        {
            try
            {
                

                service.Add(CurrentCity);
                dialog.Title = "Succesfull!";
                dialog.Hide();
            }
            catch (Exception)
            {
                dialog.Title = "Error! Please try again";
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