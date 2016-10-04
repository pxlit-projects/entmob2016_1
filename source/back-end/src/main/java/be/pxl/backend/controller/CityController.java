package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.City;
import be.pxl.backend.service.CityService;

@RestController
@RequestMapping("/cities")
public class CityController {
	
	@Autowired
	private CityService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public City getCityById(@PathVariable("id") String postal) {
		return service.find(postal);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<City> getAllCities() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{city}", method=RequestMethod.POST)
	public void addCity(@RequestBody City city) {
		service.persist(city);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteCity(@PathVariable("id") String postal) {
		service.delete(postal);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateCity(@PathVariable("id") String postal, @RequestBody City city) {
		service.update(postal, city);
	}
}
