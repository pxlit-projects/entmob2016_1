package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Variable;
import be.pxl.backend.service.IVariableService;
import be.pxl.backend.service.*;

@RestController
@RequestMapping(VariableController.VARIABLE_BASE_URL)
public class VariableController {
	public static final String VARIABLE_BASE_URL = "/variables";
	@Autowired
	private IVariableService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Variable getVariableById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Variable> getAllVariables() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{variable}", method=RequestMethod.POST)
	public void addVariable(@RequestBody Variable variable) {
		service.persist(variable);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteVariable(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateVariable(@PathVariable("id") int id, @RequestBody Variable variable) {
		service.update(id, variable);
	}
}
