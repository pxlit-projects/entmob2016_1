package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import be.pxl.backend.entity.Destination;
import be.pxl.backend.repository.DestinationRepository;
import org.springframework.stereotype.Service;

@Service
public class DestinationService implements IDestinationService {

	@Autowired
	private DestinationRepository repo;
	
	public Destination find(int id) {
		return repo.findOne(id);
	}
	
	public List<Destination> all() {
		return repo.findAll();
	}
	
	public void persist(Destination destination) {
		repo.save(destination);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
	public void update(int id, Destination destination) {
		this.delete(id);
		this.persist(destination);
	}
	
}
