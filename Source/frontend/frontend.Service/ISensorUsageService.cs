﻿using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface ISensorUsageService
    {
        List<SensorUsage> All();
        SensorUsage Find(int id);
        void Add(SensorUsage sensorUsage);
    }
}
