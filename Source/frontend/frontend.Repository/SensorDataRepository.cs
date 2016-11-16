using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;

namespace frontend.Repository
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private ISensorRepository sensorRepository;

        public SensorDataRepository(string username, string password)
        {
            sensorRepository = new SensorRepository(username, password);
        }

        public async void AddSensorData(SensorData sensorData)
        {
            var sensor = await sensorRepository.GetSensorById(sensorData.Sensor.Sensor_id);
            sensor.Data.Add(sensorData);
            sensorRepository.UpdateSensor(sensor);
        }

        public async Task<List<SensorData>> GetAllSensorData()
        {
            var sensors = await sensorRepository.GetAllSensors();
            List<SensorData> sensorData = new List<SensorData>();
            sensors.ForEach(s => s.Data.ForEach(d => sensorData.Add(d)));
            return sensorData;
        }

        public async Task<SensorData> GetSensorDataById(int id)
        {
            var sensorDataList = await GetAllSensorData();
            var sensorData = sensorDataList.FirstOrDefault(s => s.Sensor_data_id == id);
            return sensorData;
        }
    }
}
