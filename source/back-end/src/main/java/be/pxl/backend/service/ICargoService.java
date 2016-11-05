package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Cargo;

public interface ICargoService {

	public Cargo find(int id);
	
	public List<Cargo> all();
	
	public void persist(Cargo cargo);
	
	public void delete(int id);
	
	public void update(Cargo cargo);
	
	public List<Cargo> getCargoBySensor(int sensor_id);

}
