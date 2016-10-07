using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public interface ISensorUsageService
    {
        List<SensorUsage> All();
        SensorUsage Find(int id);
        void Add(SensorUsage sensorUsage);
        void Update(SensorUsage sensorUsage);
        void Delete(int id);
    }
}
