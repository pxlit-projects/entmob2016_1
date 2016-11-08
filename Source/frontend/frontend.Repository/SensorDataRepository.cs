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
        public ISensorRepository SensorRepository { get; set; }

        public SensorDataRepository(string username, string password)
        {
            SensorRepository = new SensorRepository(username, password);
        }

        public async void AddSensorData(SensorData sensorData)
        {
            var sensor = await SensorRepository.GetSensorById(sensorData.Sensor.Sensor_id);
            sensor.Data.Add(sensorData);
            SensorRepository.UpdateSensor(sensor);
        }

        public async Task<List<SensorData>> GetAllSensorData()
        {
            var sensors = await SensorRepository.GetAllSensors();
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
