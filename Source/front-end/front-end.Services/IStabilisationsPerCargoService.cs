using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface IStabilisationsPerCargoService
    {
        List<StabilisationsPerCargo> All();
        StabilisationsPerCargo Find(int id);
        void Add(StabilisationsPerCargo stabilisationsPerCargo);
        void Update(StabilisationsPerCargo stabilisationsPerCargo);
        void Delete(int id);
    }
}
