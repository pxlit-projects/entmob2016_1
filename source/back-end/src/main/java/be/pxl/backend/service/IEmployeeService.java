package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Employee;

public interface IEmployeeService {

	public Employee find(int id);
	
	public List<Employee> all();
	
	public void persist(Employee employee);
	
	public void delete(int id);
	
	public void update(Employee employee);

	public Employee getEmployeeByUsername(String username);
}
