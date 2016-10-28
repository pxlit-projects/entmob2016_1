package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.ExceedingPerCargo;

public interface IExceedingsPerCargoService {

	public ExceedingPerCargo find(int id);
	
	public List<ExceedingPerCargo> all();
	
	public void persist(ExceedingPerCargo employee);
	
	public void delete(int id);
	
}
