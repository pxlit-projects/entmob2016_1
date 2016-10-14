using front_end.Domain;
using front_end.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.App.ViewModel
{
    class DriversViewModel : INotifyPropertyChanged
    {
        IEmployeeService service;
        private ObservableCollection<Employee> drivers;
        private Employee selectedDriver;

        public DriversViewModel(IEmployeeService service)
        {
            service = this.service;
            LoadData();
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
