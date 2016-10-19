package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.SensorData;
import be.pxl.backend.service.SensorDataService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(SensorDataController.SENSORDATA_BASE_URL)
public class SensorDataController {
    public static final String SENSORDATA_BASE_URL = "/sensordata";
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

    @RequestMapping(value = "/add", method=RequestMethod.POST)
    @ResponseStatus (value = HttpStatus.CREATED)
    public void addSensorData(@RequestBody SensorData SensorData) {
        service.persist(SensorData);
    }

    @RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
    public void deleteSensorData(@PathVariable("id") int id) {
        service.delete(id);
    }

}
