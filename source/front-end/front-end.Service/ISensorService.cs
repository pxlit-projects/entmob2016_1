using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface ISensorService
    {
        List<Sensor> All();
        Sensor Find(int id);
        void Add(Sensor sensor);
        void Update(Sensor sensor);
        void Delete(int id);
        void ChangeStatus(Sensor sensor);
    }
}
