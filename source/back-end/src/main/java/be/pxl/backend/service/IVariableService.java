package be.pxl.backend.service;

import java.util.List;

import org.springframework.stereotype.Service;

import be.pxl.backend.entity.Variable;

public interface IVariableService {
	public Variable find(int id);
	
	public List<Variable> all();
	
	public void persist(Variable variable);
	
	public void delete(int id);
	
	public void update(int id, Variable variable);
}
