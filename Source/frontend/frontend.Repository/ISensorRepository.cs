using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public interface ISensorRepository
    {
        Task<List<Sensor>> GetAllSensors();
        Task<Sensor> GetSensorById(int id);
        void AddSensor(Sensor sensor);
        void UpdateSensor(Sensor sensor);
    }
}
