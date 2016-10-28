package be.pxl.backend.controller;

import java.util.List;

import be.pxl.backend.entity.Product;
import be.pxl.backend.jms.JMSMessageLogger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.service.CargoService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(CargoController.CARGO_BASE_URL)
public class CargoController {
	
	@Autowired
	private ICargoService service;
	
	@Autowired
	private JMSMessageLogger logger;

	public static final String CARGO_BASE_URL = "/cargos";
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
    public Cargo getCargoById(@PathVariable("id") int id) {
        return service.find(id);
    }
    
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Cargo> getAllCargos() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{cargo}", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addCargo(@RequestBody Cargo cargo) {
		service.persist(cargo);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteCargo(@PathVariable("id") int id) {
		service.delete(id);
	}

}
