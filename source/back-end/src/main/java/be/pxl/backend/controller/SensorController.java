package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Sensor;
import be.pxl.backend.service.SensorService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(this.SENSOR_BASE_URL)
public class SensorController {
	public static final String SENSOR_BASE_URL = "/sensors";
	@Autowired
	private ISensorService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Sensor getSensorById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Sensor> getAllCities() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{sensor}", method=RequestMethod.POST)
	public void addSensor(@RequestBody Sensor sensor) {
		service.persist(sensor);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteSensor(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateSensor(@PathVariable("id") int id, @RequestBody Sensor sensor) {
		service.update(id, sensor);
	}
}
