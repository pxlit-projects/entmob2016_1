package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.ExceedingsPerCargo;

public interface IExceedingsPerCargoService {

	public ExceedingsPerCargo find(int id);
	
	public List<ExceedingsPerCargo> all();
	
	public void persist(ExceedingsPerCargo employee);
	
	public void delete(int id);
	
	public void update(int id, ExceedingsPerCargo employee);
	
}
