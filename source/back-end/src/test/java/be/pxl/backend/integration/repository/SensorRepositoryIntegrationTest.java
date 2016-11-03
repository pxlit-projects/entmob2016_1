package be.pxl.backend.integration.repository;

import be.pxl.backend.entity.Sensor;
import be.pxl.backend.repository.SensorRepository;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.Arrays;
import java.util.List;
import static be.pxl.backend.builder.SensorBuilder.aSensor;
import static org.assertj.core.api.Assertions.assertThat;

@RunWith(SpringRunner.class)
@SpringBootTest
public class SensorRepositoryIntegrationTest {
    
    @Autowired
    private SensorRepository repo;
    
    @Before
    public void deleteAll() {
        repo.deleteAll();;
    }
    
    @Test
    public void test_persist_sensor() {
        Sensor s1 = aSensor().withSensorName("Sensor 1").build();
        
        repo.save(s1);
        
        assertThat(repo.findAll().get(0).getSensor_name().equals("Sensor 1"));
    }
    
    @Test
    public void test_delete_sensor() {
        Sensor s1 = aSensor().withSensorName("Sensor 1").build();
        Sensor s2 = aSensor().withSensorName("Sensor 2").build();
        
        repo.save(Arrays.asList(s1,s2));
        List<Sensor> sensors = repo.findAll();
        int sensor_id = sensors.get(sensors.size()-1).getSensor_id();
        
        repo.delete(sensor_id);
        
        assertThat(repo.findAll().get(0).getSensor_name().equals("Sensor 1"));
    }
    
}
