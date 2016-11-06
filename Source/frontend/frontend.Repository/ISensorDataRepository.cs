using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface ISensorDataRepository
    {
        Task<List<SensorData>> GetAllSensorData();
        Task<SensorData> GetSensorDataById(int id);
        void AddSensorData(SensorData sensorData);
        void UpdateSensorData(SensorData sensorData);
    }
}
