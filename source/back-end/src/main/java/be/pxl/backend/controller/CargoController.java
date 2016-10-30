package be.pxl.backend.controller;

import java.util.List;
import be.pxl.backend.jms.JMSMessageLogger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.service.*;

@RestController
@RequestMapping(CargoController.CARGO_BASE_URL)
public class CargoController {
	
	@Autowired
	private ICargoService service;
	
	@Autowired
	private JMSMessageLogger logger;

	public static final String CARGO_BASE_URL = "/cargos";
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json;charset=utf-8")
    public Cargo getCargoById(@PathVariable("id") int id) {
        logger.log("Fetching cargo with id: " + id);
        return service.find(id);
    }
    
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json;charset=utf-8")
	public List<Cargo> getAllCargos() {
		logger.log("Retrieving all cargos.");
        return service.all();
	}
    
    @RequestMapping(value = "/add", method=RequestMethod.POST)
    @ResponseStatus (value = HttpStatus.CREATED)
    public void addCargo(@RequestBody Cargo cargo) {
        logger.log("Adding cargo with weight: " + cargo.getWeight() + " and " + cargo.getBorders().size() + " borders.");
        service.persist(cargo);
    }
    
    @RequestMapping(value = "/update", method = RequestMethod.PUT)
    public void updateCargo(@RequestBody Cargo cargo) {
        logger.log("Updating cargo with id: " + cargo.getCargo_id() + ".");
        service.update(cargo); }
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteCargo(@PathVariable("id") int id) {
		logger.log("Deleting cargo with id: " + id + ".");
        service.delete(id);
	}

}
