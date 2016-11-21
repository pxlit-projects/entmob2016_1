package be.pxl.backend.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import be.pxl.backend.entity.Variable;
import be.pxl.backend.repository.VariableRepository;

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

}
