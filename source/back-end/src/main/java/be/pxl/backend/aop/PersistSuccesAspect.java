package be.pxl.backend.aop;

import be.pxl.backend.entity.Cargo;
import be.pxl.backend.entity.Employee;
import be.pxl.backend.entity.Sensor;
import be.pxl.backend.jms.JMSMessageLogger;
import org.aspectj.lang.annotation.AfterReturning;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Aspect
public class PersistSuccesAspect {
    
    @Autowired
    private JMSMessageLogger logger;
    
    @AfterReturning ("execution(* *.persist(..)) && args(cargo)")
    public void persist(Cargo cargo) {
        logger.log("Cargo repository succeeded: persist. Cargo with id: " + cargo.getCargo_id());
    }
    
    @AfterReturning ("execution(* *.persist(..)) && args(employee)")
    public void persist(Employee employee) {
        logger.log("Employee repository succeeded: persist. Employee with username: " + employee.getUsername());
    }
    
    @AfterReturning ("execution(* *.persist(..)) && args(sensor)")
    public void persist(Sensor sensor) {
        logger.log("Sensor repository succeeded: persist. Sensor with name: " + sensor.getSensor_name());
    }
    
}
