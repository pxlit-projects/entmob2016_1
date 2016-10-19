package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
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
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addDestination(@RequestBody Destination destination) {
		service.persist(destination);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteDestination(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update", method=RequestMethod.PUT)
	public void updateDestination(@RequestBody Destination destination) {
		service.update(destination);
	}
}
