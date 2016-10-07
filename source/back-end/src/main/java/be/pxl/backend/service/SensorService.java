package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import be.pxl.backend.entity.Employee;
import be.pxl.backend.entity.Sensor;
import be.pxl.backend.repository.SensorRepository;

@Service
public class SensorService {

	@Autowired
	private SensorRepository repo;
	
	public Sensor find(int id) {
		return repo.findOne(id);
	}
	
	public List<Sensor> all() {
		return repo.findAll();
	}
	
	public void persist(Sensor sensor) {
		repo.save(sensor);
	}
	
	public void delete(int id) {
		Sensor sens = repo.findOne(id);
		sens.setStatus(false);
		this.update(id, sens);
	}
	
	public void update(int id, Sensor sensor) {
		repo.delete(id);
		this.persist(sensor);
	}
	
}
