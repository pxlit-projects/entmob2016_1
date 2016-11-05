package be.pxl.backend.aop;

import be.pxl.backend.entity.Employee;
import be.pxl.backend.jms.JMSMessageLogger;
import org.aspectj.lang.annotation.AfterReturning;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Aspect
public class EmployeeRepositoryAspect {
    
    @Autowired
    private JMSMessageLogger logger;
    
    @AfterReturning ("execution(* *.persist(..)) && args(employee)")
    public void persist(Employee employee) {
        logger.log("Employee repository succeeded: persist. Employee with username: " + employee.getUsername());
    }
    
}
