package be.pxl.backend.controller;

import java.util.List;
import be.pxl.backend.jms.JMSMessageLogger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
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
    public ResponseEntity<Cargo> getCargoById(@PathVariable("id") int id) {
        logger.log("Fetching cargo with id: " + id);
        HttpStatus status = HttpStatus.OK;
        Cargo cargo = service.find(id);
        
        if (cargo == null)
            status = HttpStatus.NOT_FOUND;
        
        return new ResponseEntity<Cargo>(cargo, status);
    }
    
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json;charset=utf-8")
	public List<Cargo> getAllCargos() {
		logger.log("Retrieving all cargos.");
        return service.all();
	}
    
    @RequestMapping(value = "/add", method=RequestMethod.POST)
    @ResponseStatus (value = HttpStatus.CREATED)
    @PreAuthorize ("hasRole('ROLE_ADMIN')")
    public void addCargo(@RequestBody Cargo cargo) {
        logger.log("Adding cargo with weight: " + cargo.getWeight() + " and " + cargo.getBorders().size() + " borders.");
        service.persist(cargo);
    }
    
    @RequestMapping(value = "/update", method = RequestMethod.PUT)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public void updateCargo(@RequestBody Cargo cargo) {
        logger.log("Updating cargo with id: " + cargo.getCargo_id() + ".");
        service.update(cargo); }
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
	public void deleteCargo(@PathVariable("id") int id) {
		logger.log("Deleting cargo with id: " + id + ".");
        service.delete(id);
	}

}
