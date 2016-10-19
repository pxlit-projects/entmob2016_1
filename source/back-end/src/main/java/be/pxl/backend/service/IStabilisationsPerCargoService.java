package be.pxl.backend.service;

import java.util.List;

import org.springframework.stereotype.Service;

import be.pxl.backend.entity.StabilisationsPerCargo;

public interface IStabilisationsPerCargoService {
	
	public StabilisationsPerCargo find(int id);
	
	public List<StabilisationsPerCargo> all();
	
	public void persist(StabilisationsPerCargo stabilisationsPerCargo);
	
	public void delete(int id);
	
}
