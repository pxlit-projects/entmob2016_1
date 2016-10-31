package be.pxl.backend.aop;

import be.pxl.backend.entity.Cargo;
import be.pxl.backend.jms.JMSMessageLogger;
import org.aspectj.lang.annotation.AfterReturning;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Aspect
@Component
public class CargoRepositoryAspect {
    
    @Autowired
    private JMSMessageLogger logger;
    
    @AfterReturning ("execution(* *.persist(..)) && args(cargo)")
    public void persist(Cargo cargo) {
        logger.log("Cargo repository succeeded: persist. Cargo with id: " + cargo.getCargo_id());
    }
    
}
