using frontend.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public class SensorUsageRepository : ISensorUsageRepository
    {
        public HttpClient Client { get; set; }

        public ISensorRepository SensorRepository { get; set; }

        public IEmployeeRepository EmployeeRepository { get; set; }

        public SensorUsageRepository()
        {
            SensorRepository = new SensorRepository();
            EmployeeRepository = new EmployeeRepository();
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<SensorUsage>> GetAllSensorUsages()
        {
            var sensors = await SensorRepository.GetAllSensors();
            List<SensorUsage> usages = new List<SensorUsage>();
            sensors.ForEach(s => s.Usages.ForEach(u => usages.Add(u)));
            return usages;
        }

        public async Task<SensorUsage> GetSensorUsageById(int id)
        {
            var usages = await GetAllSensorUsages();
            var usage = usages.FirstOrDefault(u => u.Sensor_usage_id == id);
            return usage;
        }

        public async void AddSensorUsage(SensorUsage sensorUsage)
        {
            var sensor = await SensorRepository.GetSensorById(sensorUsage.Sensor.Sensor_id);
            var employee = await EmployeeRepository.GetEmployeeById(sensorUsage.Employee.Employee_id);
            sensor.Usages.Add(sensorUsage);
            employee.Usages.Add(sensorUsage);
            SensorRepository.UpdateSensor(sensor);
            EmployeeRepository.UpdateEmployee(employee);
        }
    }
}
