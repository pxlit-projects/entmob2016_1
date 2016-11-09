using frontend.Domain;
using frontend.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.ViewModels
{
    public class ExceedingsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ExceedingPerCargo> exceedings;
        private ExceedingPerCargo selectedExceeding;
        private IExceedingsPerCargoService service;

        public ExceedingsViewModel(IExceedingsPerCargoService service)
        {
            this.service = service;
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        

        public ObservableCollection<ExceedingPerCargo> Exceedings
        {
            get
            {
                return exceedings;
            }
            set
            {
                exceedings = value;
                RaisePropertyChanged("Exceedings");
            }
        }

        public ExceedingPerCargo SelectedExceeding
        {
            get
            {
                return selectedExceeding;
            }
            set
            {
                selectedExceeding = value;
                RaisePropertyChanged("SelectedCargo");
            }
        }

        private void LoadData()
        {
            var dummy = service.All().OrderBy(d => d.Exceeding_per_cargo_id);
            Exceedings = new ObservableCollection<ExceedingPerCargo>(dummy);
            SelectedExceeding = exceedings.ElementAt(0);
        }

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
