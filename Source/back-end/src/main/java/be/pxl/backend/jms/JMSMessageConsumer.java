package be.pxl.backend.jms;

import be.pxl.backend.entity.Log;
import be.pxl.backend.repository.LogRepository;
import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Component;
import javax.jms.Message;

@Component
public class JMSMessageConsumer {
    
    private LogRepository repo;
    
    public JMSMessageConsumer(LogRepository repo) {
        this.repo = repo;
    }
    
    @JmsListener(destination = "LoggerQueue")
    public void onMessage(Message message) {
        Log log = new Log();
        log.setMessage(String.valueOf(message));
        repo.save(log);
    }
}
