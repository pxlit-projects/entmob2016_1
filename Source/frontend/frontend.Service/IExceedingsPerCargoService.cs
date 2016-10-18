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
        List<ExceedingsPerCargo> All();
        ExceedingsPerCargo Find(int id);
        void Add(ExceedingsPerCargo exceedingsPerCargo);
        void Update(ExceedingsPerCargo exceedingsPerCargo);
        void Delete(int id);
    }
}
