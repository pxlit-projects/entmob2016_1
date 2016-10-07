using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface ICargoService
    {
        List<Cargo> All();
        Cargo Find(int id);
        void Add(Cargo cargo);
        void Update(Cargo cargo);
        void Delete(int id);
    }
}
