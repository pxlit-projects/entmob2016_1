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

@RestController
@RequestMapping("/sensorusages")
public class SensorUsageController {
	
	@Autowired
	private SensorUsageService service;
	
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
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateSensorUsage(@PathVariable("id") int id, @RequestBody SensorUsage sensorUsage) {
		service.update(id, sensorUsage);
	}
}
