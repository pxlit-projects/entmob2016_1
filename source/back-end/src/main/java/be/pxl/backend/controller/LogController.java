package be.pxl.backend.controller;

import java.util.List;

import be.pxl.backend.entity.Log;
import be.pxl.backend.jms.JMSMessageLogger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.service.*;

@RestController
@RequestMapping(LogController.LOG_BASE_URL)
public class LogController {
    
    @Autowired
    private ILogService service;
    
    @Autowired
    private JMSMessageLogger logger;
    
    public static final String LOG_BASE_URL = "/logs";
    
    @RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json;charset=utf-8")
    public List<Log> getAllLogs() {
      //  logger.log("Retrieving all logs.");
        return service.all();
    }
    
}
