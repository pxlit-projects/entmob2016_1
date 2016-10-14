using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
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
