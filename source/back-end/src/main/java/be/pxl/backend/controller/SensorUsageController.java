package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.SensorUsage;
import be.pxl.backend.service.SensorUsageService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(SensorUsageController.SENSORUSAGE_BASE_URL)
public class SensorUsageController {
	public static final String SENSORUSAGE_BASE_URL = "/sensorusages";
	@Autowired
	private ISensorUsageService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public SensorUsage getSensorUsageById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<SensorUsage> getAllSensorUsages() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{SensorUsage}", method=RequestMethod.POST)
	public void addSensorUsage(@RequestBody SensorUsage sensorUsage) {
		service.persist(sensorUsage);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteSensorUsage(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update", method=RequestMethod.PUT)
	public void updateSensorUsage(@RequestBody SensorUsage sensorUsage) {
		service.update(sensorUsage);
	}
}
