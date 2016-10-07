using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface ISensorUsageRepository
    {
        Task<IEnumerable<SensorUsage>> GetAllSensorUsage();
        Task<SensorUsage> GetSensorById(int id);
        void AddSensorUsage(SensorUsage sensorUsage);
        void UpdateSensorUsage(SensorUsage sensorUsage);
        void DeleteSensorUsage(int id);
    }
}
