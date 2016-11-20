package be.pxl.backend.unit;

import be.pxl.backend.controller.SensorController;
import be.pxl.backend.entity.Sensor;
import be.pxl.backend.jms.JMSMessageLogger;
import be.pxl.backend.service.SensorService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.springframework.test.context.junit4.SpringRunner;
import static be.pxl.backend.builder.SensorBuilder.*;
import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.when;

@RunWith(SpringRunner.class)
public class SensorControllerUnitTest {
    
    @InjectMocks
    private SensorController controller;
    
    @Mock
    private SensorService service;
    
    @Mock
    private JMSMessageLogger logger;

    @Test
    public void get_sensor_by_id() {
        Sensor sensor = aSensor().withSensorName("Sensor 1").build();
        
        when(service.find(1)).thenReturn(sensor);
        
        assertThat(controller.getSensorById(1).getBody().getSensor_name().equals("Sensor 1"));
    }
    
}
