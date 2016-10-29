using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface ISensorService
    {
        List<Sensor> All();
        Sensor Find(int id);
        void Add(Sensor sensor);
        void Update(Sensor sensor);
        void ChangeStatus(Sensor sensor);
    }
}
