package be.pxl.backend.service;

import java.util.ArrayList;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.backend.entity.Employee;
import be.pxl.backend.entity.SensorData;
import be.pxl.backend.repository.SensorDataRepository;

@Service
public class SensorDataService implements ISensorDataService {

    @Autowired
    private SensorDataRepository repo;

    public List<SensorData> find(int id) {
        List<SensorData> data = new ArrayList<>();

        for (SensorData single:repo.findAll()) {
            if(single.getSensor_usage().getSensor_usage_id() == id){
                data.add(single);
            }
        }
        return data;
    }

    public List<SensorData> all() {
        return repo.findAll();
    }

    public void persist(SensorData sensorData) {
        repo.save(sensorData);
    }

    public void delete(int id) {
        repo.delete(id);
    }

    public void update(SensorData sensorData) {
        repo.save(sensorData);
    }

}
