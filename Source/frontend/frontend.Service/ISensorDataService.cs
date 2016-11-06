using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface ISensorDataService
    {
        List<SensorData> All();
        SensorData Find(int id);
        void Add(SensorData sensorData);
    }
}
