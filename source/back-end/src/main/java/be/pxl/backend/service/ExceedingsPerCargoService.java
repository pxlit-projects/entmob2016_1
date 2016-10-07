package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.ExceedingsPerCargo;
import be.pxl.backend.repository.ExceedingsPerCargoRepository;

@Service
public class ExceedingsPerCargoService {

	@Autowired
	private ExceedingsPerCargoRepository repo;
	
	public ExceedingsPerCargo find(int id) {
		return repo.findOne(id);
	}
	
	public List<ExceedingsPerCargo> all() {
		return repo.findAll();
	}
	
	public void persist(ExceedingsPerCargo exceedingsPerCargo) {
		repo.save(exceedingsPerCargo);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
	public void update(int id, ExceedingsPerCargo exceedingsPerCargo) {
		this.delete(id);
		this.persist(exceedingsPerCargo);
	}
	
}
