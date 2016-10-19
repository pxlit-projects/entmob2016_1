package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.ExceedingsPerCargo;
import be.pxl.backend.service.ExceedingsPerCargoService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(ExceedingsPerCargoController.EXCEEDINGSPERCARGO_BASE_URL)
public class ExceedingsPerCargoController {
	
	@Autowired
	private IExceedingsPerCargoService service;

	public static final String EXCEEDINGSPERCARGO_BASE_URL = "/exceedingspercargo";
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public ExceedingsPerCargo getExceedingsPerCargoById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<ExceedingsPerCargo> getAllExceedingsPerCargos() {
		return service.all();
	}
	
	@RequestMapping(value = "/add", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addExceedingsPerCargo(@RequestBody ExceedingsPerCargo exceedingsPerCargo) {
		service.persist(exceedingsPerCargo);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteExceedingsPerCargo(@PathVariable("id") int id) {
		service.delete(id);
	}

}
