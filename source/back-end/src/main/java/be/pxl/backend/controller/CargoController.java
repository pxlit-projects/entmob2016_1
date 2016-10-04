package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.service.CargoService;

@RestController
@RequestMapping("/cargos")
public class CargoController {
	
	@Autowired
	private CargoService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Cargo getCargoById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Cargo> getAllCargos() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{cargo}", method=RequestMethod.POST)
	public void addCargo(@RequestBody Cargo cargo) {
		service.persist(cargo);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteCargo(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateCargo(@PathVariable("id") int id, @RequestBody Cargo cargo) {
		service.update(id, cargo);
	}
}
