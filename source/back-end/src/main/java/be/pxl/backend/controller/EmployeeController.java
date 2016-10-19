package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.Employee;
import be.pxl.backend.service.EmployeeService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(EmployeeController.EMPLOYEE_BASE_URL)
public class EmployeeController {
	public static final String EMPLOYEE_BASE_URL = "/employees";
	@Autowired
	private IEmployeeService service;
	
	@RequestMapping(value = "/get/id/{id}", method = RequestMethod.GET, produces="application/json")
	public Employee getEmployeeById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Employee> getAllEmployees() {
		return service.all();
	}
	
	@RequestMapping(value = "/add", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addEmployee(@RequestBody Employee employee) {
		service.persist(employee);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteEmployee(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update", method=RequestMethod.PUT)
	public void updateEmployee(@RequestBody Employee employee) {
		service.update(employee);
	}

	@RequestMapping(value = "/get/username/{username}", method = RequestMethod.GET, produces = "application/json")
	public Employee getEmployeeByUsername(@PathVariable("username") String username) {
		return service.getEmployeeByUsername(username);
	}
	
}
