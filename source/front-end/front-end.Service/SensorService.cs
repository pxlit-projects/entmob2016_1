using front_end.Repository;
using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
{
    public class SensorService : ISensorService
    {
        private SensorRepository sensorRepository;

        public SensorService()
        {
            sensorRepository = new SensorRepository();
        }

        public void Add(Sensor sensor)
        {
            sensorRepository.AddSensor(sensor);
        }

        public List<Sensor> All()
        {
            return sensorRepository.GetAllSensors().Result.ToList();
        }

        public void Delete(int id)
        {
            sensorRepository.DeleteSensor(id);
        }

        public Sensor Find(int id)
        {
            return sensorRepository.GetSensorById(id).Result;
        }

        public void Update(Sensor sensor)
        {
            sensorRepository.UpdateSensor(sensor);
        }
    }
}
