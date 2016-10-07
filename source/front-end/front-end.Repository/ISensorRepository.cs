using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public interface ISensorRepository
    {
        Task<IEnumerable<Sensor>> GetAllSensors();
        Task<Sensor> GetSensorById(int id);
        void AddSensor(Sensor sensor);
        void UpdateSensor(Sensor sensor);
        void DeleteSensor(int id);
    }
}
