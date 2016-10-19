package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import be.pxl.backend.entity.Variable;
import be.pxl.backend.repository.VariableRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class VariableService implements IVariableService {

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
	
	public void update(Variable variable) {
		Variable v = repo.findOne(variable.getVariable_id());
		v.copy(variable);
		repo.save(v);
	}
}
