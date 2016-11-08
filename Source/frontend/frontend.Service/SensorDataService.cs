using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;
using frontend.Repository;

namespace frontend.Service
{
    public class SensorDataService : ISensorDataService
    {
        private SensorDataRepository repo;

        public SensorDataService(string username, string password)
        {
            repo = new SensorDataRepository(username, password);
        }

        public void Add(SensorData sensorData)
        {
            repo.AddSensorData(sensorData);
        }

        public List<SensorData> All()
        {
            var sensorData = repo.GetAllSensorData().Result;
            if (sensorData != null)
            {
                return sensorData;
            }
            else
            {
                return new List<SensorData>();
            }
        }

        public SensorData Find(int id)
        {
            var sensorData = repo.GetSensorDataById(id).Result;
            if (sensorData != null)
            {
                return sensorData;
            }
            else
            {
                return new SensorData();
            }
        }
    }
}
