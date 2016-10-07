package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.Employee;
import be.pxl.backend.entity.Login;
import be.pxl.backend.repository.EmployeeRepository;

@Service
public class EmployeeService {

	@Autowired
	private EmployeeRepository repo;
	
	public Employee find(int id) {
		return repo.findOne(id);
	}
	
	public List<Employee> all() {
		return repo.findAll();
	}
	
	public void persist(Employee employee) {
		repo.save(employee);
	}
	
	public void delete(int id) {
		Employee emp = repo.findOne(id);
		emp.setStatus(false);
		this.update(id, emp);
	}
	
	public void update(int id, Employee employee) {
		repo.delete(id);
		this.persist(employee);
	}
	
}
