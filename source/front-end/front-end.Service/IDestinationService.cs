using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
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
