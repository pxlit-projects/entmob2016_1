package be.pxl.backend.controller;

import java.util.List;
import be.pxl.backend.jms.JMSMessageLogger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.Sensor;
import be.pxl.backend.service.*;

@RestController
@RequestMapping(SensorController.SENSOR_BASE_URL)
public class SensorController {
	
	public static final String SENSOR_BASE_URL = "/sensors";
	
	@Autowired
	private ISensorService service;
	
	@Autowired
	private JMSMessageLogger logger;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json;charset=utf-8")
	public ResponseEntity<Sensor> getSensorById(@PathVariable("id") int id) {
		logger.log("Fetching sensor with id: " + id + ".");
        HttpStatus status = HttpStatus.OK;
		Sensor sensor = service.find(id);
        
        if (sensor == null)
            status = HttpStatus.NOT_FOUND;
        
        return new ResponseEntity<Sensor>(sensor, status);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json;charset=utf-8")
	public List<Sensor> getAllSensors() {
		logger.log("Retrieving all sensors.");
        return service.all();
	}
	
	@RequestMapping(value = "/add", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
    @PreAuthorize ("hasRole('ROLE_ADMIN')")
	public void addSensor(@RequestBody Sensor sensor) {
		logger.log("Adding new sensor with name: " + sensor.getSensor_name() + ".");
        service.persist(sensor);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
	public void deleteSensor(@PathVariable("id") int id) {
		logger.log("Deleting sensor with id: " + id + ".");
        service.delete(id);
	}
	
	@RequestMapping(value = "/update", method=RequestMethod.PUT)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
	public void updateSensor(@RequestBody Sensor sensor) {
		logger.log("Updating sensor with id: " + sensor.getSensor_id() + ".");
        service.update( sensor);
	}
}
