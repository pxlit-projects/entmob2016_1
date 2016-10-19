package be.pxl.backend.service;

import java.util.List;

import be.pxl.backend.entity.SensorUsage;

public interface ISensorUsageService {
	public SensorUsage find(int id);
	
	public List<SensorUsage> all();
	
	public void persist(SensorUsage sensorUsage);
	
	public void delete(int id);
	
}
