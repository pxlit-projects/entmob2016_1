package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Product;
import be.pxl.backend.entity.SensorData;

public interface ISensorDataService {

    public List<SensorData> find(int id);

    public List<SensorData> all();

    public void persist(SensorData sensorData);

    public void delete(int id);
    
}
