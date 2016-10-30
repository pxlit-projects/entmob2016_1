package be.pxl.backend.jms;

import be.pxl.backend.entity.Log;
import be.pxl.backend.service.ILogService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Component;

import javax.jms.JMSException;
import javax.jms.TextMessage;

@Component
public class JMSMessageConsumer {
    
    @Autowired
    private ILogService service;
    
    @JmsListener(destination = "LoggerQueue")
    public void onMessage(TextMessage message) {
        Log log = new Log();
        try {
            log.setMessage(message.getText());
        } catch (JMSException e) {
            log.setMessage("Log failed.");
        }
        service.persist(log);
    }
}
