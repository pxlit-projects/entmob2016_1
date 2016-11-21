using frontend.Domain;
using frontend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public class SensorService : ISensorService
    {
        private SensorRepository sensorRepository;

        public SensorService(string username, string password)
        {
            sensorRepository = new SensorRepository(username, password);
        }

        public void Add(Sensor sensor)
        {
            sensorRepository.AddSensor(sensor);
        }

        public List<Sensor> All()
        {
            var sensors = sensorRepository.GetAllSensors().Result.ToList();
            return sensors;
        }

        public Sensor Find(int id)
        {
            var sensor = sensorRepository.GetSensorById(id).Result;
            if (sensor != null)
            {
                return sensor;
            }
            else
            {
                return new Sensor();
            }
        }

        public void Update(Sensor sensor)
        {
            sensorRepository.UpdateSensor(sensor);
        }

        public void ChangeStatus(Sensor sensor)
        {
            if (sensor.Status == true)
            {
                sensor.Status = false;
            }
            else
            {
                sensor.Status = true;
            }
            sensorRepository.UpdateSensor(sensor);
        }
    }
}
