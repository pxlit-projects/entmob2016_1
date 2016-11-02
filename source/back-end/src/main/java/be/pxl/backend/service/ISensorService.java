package be.pxl.backend.service;

import java.util.List;

import be.pxl.backend.entity.Sensor;

public interface ISensorService {
	public Sensor find(int id);
	
	public List<Sensor> all();
	
	public void persist(Sensor sensor);
	
	public void delete(int id);
	
	public void update(Sensor sensor);
	
	public void hardDelete(int id);
}
