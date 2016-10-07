package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import be.pxl.backend.entity.SensorUsage;
import be.pxl.backend.repository.SensorUsageRepository;

@Service
public class SensorUsageService implements ISensorUsageService {

	@Autowired
	private SensorUsageRepository repo;
	
	public SensorUsage find(int id) {
		return repo.findOne(id);
	}
	
	public List<SensorUsage> all() {
		return repo.findAll();
	}
	
	public void persist(SensorUsage sensorUsage) {
		repo.save(sensorUsage);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
	public void update(int id, SensorUsage sensorUsage) {
		this.delete(id);
		this.persist(sensorUsage);
	}
	
}
