package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Employee;
import be.pxl.backend.service.EmployeeService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(EmployeeController.EMPLOYEE_BASE_URL)
public class EmployeeController {
	public static final String EMPLOYEE_BASE_URL = "/employees";
	@Autowired
	private IEmployeeService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Employee getEmployeeById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Employee> getAllEmployees() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{employee}", method=RequestMethod.POST)
	public void addEmployee(@RequestBody Employee employee) {
		service.persist(employee);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteEmployee(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateEmployee(@PathVariable("id") int id, @RequestBody Employee employee) {
		service.update(id, employee);
	}
	
}
