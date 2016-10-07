package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Destination;
import be.pxl.backend.service.IDestinationService;

@RestController
@RequestMapping(DestinationController.DESTINATIONS_BASE_URL)
public class DestinationController {
	public static final String DESTINATIONS_BASE_URL = "/destinations";
	@Autowired
	private IDestinationService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Destination getDestinationById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Destination> getAllDestinations() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{destination}", method=RequestMethod.POST)
	public void addDestination(@RequestBody Destination destination) {
		service.persist(destination);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteDestination(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateDestination(@PathVariable("id") int id, @RequestBody Destination destination) {
		service.update(id, destination);
	}
}
