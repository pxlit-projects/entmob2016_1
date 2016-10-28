using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface IStabilisationsPerCargoService
    {
        List<StabilisationPerCargo> All();
        StabilisationPerCargo Find(int id);
        void Add(StabilisationPerCargo stabilisationsPerCargo);
        void Update(StabilisationPerCargo stabilisationsPerCargo);
        void Delete(int id);
    }
}
