using frontend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.ViewModels
{
    public class ExceedingsViewModel
    {
        private IExceedingsPerCargoService service;

        public ExceedingsViewModel(IExceedingsPerCargoService service)
        {
            this.service = service;
        }
    }
}
