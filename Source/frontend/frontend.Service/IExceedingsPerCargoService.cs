using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface IExceedingsPerCargoService
    {
        List<ExceedingPerCargo> All();
        ExceedingPerCargo Find(int id);
        void Add(ExceedingPerCargo exceedingsPerCargo);
        void Update(ExceedingPerCargo exceedingsPerCargo);
        void Delete(int id);
    }
}
