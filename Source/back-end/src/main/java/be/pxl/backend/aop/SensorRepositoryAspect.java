package be.pxl.backend.aop;

import be.pxl.backend.entity.Sensor;
import be.pxl.backend.jms.JMSMessageLogger;
import org.aspectj.lang.annotation.AfterReturning;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Aspect
@Component
public class SensorRepositoryAspect {
 
    @Autowired
    private JMSMessageLogger logger;
    
    @AfterReturning ("execution(* *.persist(..)) && args(sensor)")
    public void persist(Sensor sensor) {
        logger.log("Sensor repository succeeded: persist. Sensor with name: " + sensor.getSensor_name());
    }
    
}
