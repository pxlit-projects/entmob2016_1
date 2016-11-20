package be.pxl.backend.unit;

/*
Unit test to show I know how to write unit tests.
 */

import be.pxl.backend.controller.SensorController;
import be.pxl.backend.entity.Sensor;
import be.pxl.backend.service.SensorService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.springframework.test.context.junit4.SpringRunner;
import static be.pxl.backend.builder.SensorBuilder.*;
import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

@RunWith(SpringRunner.class)
public class SensorControllerUnitTest {

    @Test
    public void get_sensor_by_id() {
        Sensor sensor = aSensor().withSensorName("Sensor 1").build();
        SensorController controller = new SensorController();
        SensorService service = mock(SensorService.class);
        
        when(service.find(1)).thenReturn(sensor);
        
        controller.setService(service);
        
        System.out.println("SENSOR: " + controller.getSensorById(1));
        
        assertThat(controller.getSensorById(1).getBody().getSensor_name().equals("Sensor 1"));
    }
    
}
