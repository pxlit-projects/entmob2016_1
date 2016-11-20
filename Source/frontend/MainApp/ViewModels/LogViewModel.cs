using frontend.Domain;
using frontend.Service;
using MainApp.Authentication;
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
        private List<Log> logs;
        private ILogService service;

        public LogViewModel(ILogService service)
        {
            this.service = service;
            LoadData();
        }

        public List<Log> Logs
        {
            get
            {
                return logs;
            }
            set
            {
                logs = value;
            }
        }

        private void LoadData()
        {
            var dummy = service.All().OrderByDescending(d => d.Time);
            Logs = new List<Log>(dummy);
        }
    }
}
