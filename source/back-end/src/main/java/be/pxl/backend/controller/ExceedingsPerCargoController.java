package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.ExceedingsPerCargo;
import be.pxl.backend.service.ExceedingsPerCargoService;

@RestController
@RequestMapping("/exceedingsPerCargos")
public class ExceedingsPerCargoController {
	
	@Autowired
	private ExceedingsPerCargoService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public ExceedingsPerCargo getExceedingsPerCargoById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<ExceedingsPerCargo> getAllExceedingsPerCargos() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{exceedingsPerCargo}", method=RequestMethod.POST)
	public void addExceedingsPerCargo(@RequestBody ExceedingsPerCargo exceedingsPerCargo) {
		service.persist(exceedingsPerCargo);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteExceedingsPerCargo(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateExceedingsPerCargo(@PathVariable("id") int id, @RequestBody ExceedingsPerCargo exceedingsPerCargo) {
		service.update(id, exceedingsPerCargo);
	}
}