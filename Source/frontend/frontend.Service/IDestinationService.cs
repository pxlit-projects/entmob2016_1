using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface IDestinationService
    {
        List<Destination> All();
        Destination Find(int id);
        void Add(Destination destination);
        void Update(Destination destination);
        void Delete(int id);
    }
}
