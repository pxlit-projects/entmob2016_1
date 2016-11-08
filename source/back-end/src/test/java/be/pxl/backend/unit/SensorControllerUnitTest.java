package be.pxl.backend.unit;

/*
Unit test to show I know how to write unit tests.
 */

import be.pxl.backend.entity.Sensor;
import be.pxl.backend.service.SensorService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.context.junit4.SpringRunner;
import static be.pxl.backend.builder.SensorBuilder.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

@RunWith(SpringRunner.class)
public class SensorControllerUnitTest {
    
    @Test
    public void get_sensor_by_id() {
        SensorService service = mock(SensorService.class);
        Sensor sensor = aSensor().withSensorName("Sensor 1").build();
        
      //  when(service.find().thenReturn(service));
    }
    
}
