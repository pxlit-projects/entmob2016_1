package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import be.pxl.backend.entity.Variable;
import be.pxl.backend.repository.VariableRepository;

@Component
public class VariableService {

	@Autowired
	private VariableRepository repo;
	
	public Variable find(int id) {
		return repo.findOne(id);
	}
	
	public List<Variable> all() {
		return repo.findAll();
	}
	
	public void persist(Variable variable) {
		repo.save(variable);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
	public void update(int id, Variable variable) {
		this.delete(id);
		this.persist(variable);
	}
}
