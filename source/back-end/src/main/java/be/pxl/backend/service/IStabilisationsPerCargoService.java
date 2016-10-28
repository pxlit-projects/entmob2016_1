package be.pxl.backend.service;

import java.util.List;

import be.pxl.backend.entity.StabilisationPerCargo;

public interface IStabilisationsPerCargoService {
	
	public StabilisationPerCargo find(int id);
	
	public List<StabilisationPerCargo> all();
	
	public void persist(StabilisationPerCargo stabilisationPerCargo);
	
	public void delete(int id);
	
}
