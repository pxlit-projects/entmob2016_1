package be.pxl.backend.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.backend.entity.Variable;
import be.pxl.backend.jms.JMSMessageLogger;
import be.pxl.backend.service.IVariableService;

@RestController
@RequestMapping(VariableController.VARIABLE_BASE_URL)
public class VariableController {
	public static final String VARIABLE_BASE_URL = "/variables";
	
	@Autowired
	private IVariableService service;
	
	@Autowired
	private JMSMessageLogger logger;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public ResponseEntity<Variable> getVariableById(@PathVariable("id") int id) {
		logger.log("Fetching variable with id: " + id + ".");
        HttpStatus status = HttpStatus.OK;
		Variable variable = service.find(id);
        
        if (variable == null)
            status = HttpStatus.NOT_FOUND;
        
        return new ResponseEntity<Variable>(variable, status);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Variable> getAllVariables() {
		logger.log("Retrieving all variables.");
		return service.all();
	}
}
