package be.pxl.backend.service;

import java.util.List;

import be.pxl.backend.entity.Variable;

public interface IVariableService {
	public Variable find(int id);
	
	public List<Variable> all();
}
