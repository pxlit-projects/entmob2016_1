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
    public class LogViewModel
    {
        private ObservableCollection<Log> logs;
        private ILogService service;

        public LogViewModel(ILogService service)
        {
            this.service = service;
            LoadData();
        }

        public ObservableCollection<Log> Logs
        {
            get
            {
                return logs;
            }
            set
            {
                logs = value;
                RaisePropertyChanged("Logs");
            }
        }

        private void LoadData()
        {
            var dummy = service.All().OrderByDescending(d => d.Log_id);
            Logs = new ObservableCollection<Log>(dummy);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
