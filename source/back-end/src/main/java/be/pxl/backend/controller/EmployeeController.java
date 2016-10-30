package be.pxl.backend.controller;

import java.util.List;
import be.pxl.backend.jms.JMSMessageLogger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.Employee;
import be.pxl.backend.service.*;

@RestController
@RequestMapping(EmployeeController.EMPLOYEE_BASE_URL)
public class EmployeeController {
	
	public static final String EMPLOYEE_BASE_URL = "/employees";
	
	@Autowired
	private IEmployeeService service;
	
	@Autowired
	private JMSMessageLogger logger;
	
	@RequestMapping(value = "/get/id/{id}", method = RequestMethod.GET, produces="application/json;charset=utf-8")
	public ResponseEntity<Employee> getEmployeeById(@PathVariable("id") int id) {
		logger.log("Fetching employee with id: " + id + ".");
		HttpStatus status = HttpStatus.OK;
		Employee employee = service.find(id);
		
		if (employee == null)
			status = HttpStatus.NOT_FOUND;
		
		return new ResponseEntity<Employee>(employee, status);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json;charset=utf-8")
	public List<Employee> getAllEmployees() {
		logger.log("Retrieving all employees.");
		return service.all();
	}
	
	@RequestMapping(value = "/add", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	@PreAuthorize("hasRole('ROLE_ADMIN')")
	public void addEmployee(@RequestBody Employee employee) {
		logger.log("Adding employee with username: " + employee.getUsername() + ".");
		service.persist(employee);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	@PreAuthorize ("hasRole('ROLE_ADMIN')")
	public void deleteEmployee(@PathVariable("id") int id) {
		logger.log("Deleting employee with id: " + id + ".");
		service.delete(id);
	}
	
	@RequestMapping(value = "/update", method=RequestMethod.PUT)
	@PreAuthorize("hasRole('ROLE_ADMIN')")
	public void updateEmployee(@RequestBody Employee employee) {
        logger.log("Updating employee with id: " + employee.getEmployee_id() + ".");
		service.update(employee);
	}

	@RequestMapping(value = "/get/username/{username}", method = RequestMethod.GET, produces = "application/json;charset=utf-8")
	public Employee getEmployeeByUsername(@PathVariable("username") String username) {
        logger.log("Fetching employee with username: " + username + ".");
		return service.getEmployeeByUsername(username);
	}
	
}
