﻿using front_end.Repository;
using front_end.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Services
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

        public void Delete(int id)
        {
            sensorUsageRepository.DeleteSensorUsage(id);
        }

        public SensorUsage Find(int id)
        {
            return sensorUsageRepository.GetSensorUsageById(id).Result;
        }

        public void Update(SensorUsage sensorUsage)
        {
            sensorUsageRepository.UpdateSensorUsage(sensorUsage);
        }
    }
}
