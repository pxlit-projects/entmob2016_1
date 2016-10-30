using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class SensorUsageService : ISensorUsageService
    {
        private SensorUsageRepository sensorUsageRepository;

        public SensorUsageService()
        {
            sensorUsageRepository = new SensorUsageRepository();
        }

        public void Add(SensorUsage sensorUsage)
        {
            sensorUsageRepository.AddSensorUsage(sensorUsage);
        }

        public List<SensorUsage> All()
        {
            return sensorUsageRepository.GetAllSensorUsages().Result.ToList();
        }

        public SensorUsage Find(int id)
        {
            return sensorUsageRepository.GetSensorUsageById(id).Result;
        }
    }
}
