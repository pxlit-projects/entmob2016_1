package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.StabilisationsPerCargo;
import be.pxl.backend.service.StabilisationsPerCargoService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(this.STABILISATIONSPERCARGO_BASE_URL)
public class StabilisationsPerCargoController {
	public static final String STABILISATIONSPERCARGO_BASE_URL = "/stabilisationspercargos";
	@Autowired
	private IStabilisationsPerCargoService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public StabilisationsPerCargo getStabilisationsPerCargoById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<StabilisationsPerCargo> getAllStabilisationsPerCargos() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{StabilisationsPerCargo}", method=RequestMethod.POST)
	public void addStabilisationsPerCargo(@RequestBody StabilisationsPerCargo stabilisationsPerCargo) {
		service.persist(stabilisationsPerCargo);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteStabilisationsPerCargo(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateStabilisationsPerCargo(@PathVariable("id") int id, @RequestBody StabilisationsPerCargo StabilisationsPerCargo) {
		service.update(id, StabilisationsPerCargo);
	}
}
