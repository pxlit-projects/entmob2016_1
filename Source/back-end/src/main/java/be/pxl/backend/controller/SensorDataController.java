package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.SensorData;
import be.pxl.backend.service.SensorDataService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping("/sensordata")
public class SensorDataController {

    @Autowired
    private ISensorDataService service;

    @RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
    public List<SensorData> getSensorDataById(@PathVariable("id") int id) {
        return service.find(id);
    }
    @RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
    public List<SensorData> getAllCities() {
        return service.all();
    }

    @RequestMapping(value = "/add/{SensorData}", method=RequestMethod.POST)
    public void addSensorData(@RequestBody SensorData SensorData) {
        service.persist(SensorData);
    }

    @RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
    public void deleteSensorData(@PathVariable("id") int id) {
        service.delete(id);
    }

    @RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
    public void updateSensorData(@PathVariable("id") int id, @RequestBody SensorData SensorData) {
        service.update(id, SensorData);
    }
}
