using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface ISensorUsageRepository
    {
        Task<IEnumerable<SensorUsage>> GetAllSensorUsages();
        Task<SensorUsage> GetSensorUsageById(int id);
        void AddSensorUsage(SensorUsage sensorUsage);
        void UpdateSensorUsage(SensorUsage sensorUsage);
        void DeleteSensorUsage(int id);
    }
}
