package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.StabilisationsPerCargo;
import be.pxl.backend.service.StabilisationsPerCargoService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(StabilisationsPerCargoController.STABILISATIONSPERCARGO_BASE_URL)
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
	
	@RequestMapping(value = "/add", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addStabilisationsPerCargo(@RequestBody StabilisationsPerCargo stabilisationsPerCargo) {
		service.persist(stabilisationsPerCargo);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteStabilisationsPerCargo(@PathVariable("id") int id) {
		service.delete(id);
	}

}
