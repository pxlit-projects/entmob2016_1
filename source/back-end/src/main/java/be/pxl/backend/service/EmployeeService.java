package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.Employee;
import be.pxl.backend.repository.EmployeeRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class EmployeeService implements IEmployeeService {

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
		Employee employee = repo.findOne(id);
		employee.setStatus(false);
		this.update(employee);
	}
	
	public void update(Employee employee) {	repo.save(employee); }

	public Employee getEmployeeByUsername(String username) {
		return repo.getEmployeeByUsername(username);
	}
	
	public void hardDelete(int id) { repo.delete(id); }
	
}
