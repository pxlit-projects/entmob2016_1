package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.ExceedingPerCargo;
import be.pxl.backend.repository.ExceedingsPerCargoRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class ExceedingsPerCargoService implements IExceedingsPerCargoService {

	@Autowired
	private ExceedingsPerCargoRepository repo;
	
	public ExceedingPerCargo find(int id) {
		return repo.findOne(id);
	}
	
	public List<ExceedingPerCargo> all() {
		return repo.findAll();
	}
	
	public void persist(ExceedingPerCargo exceedingPerCargo) {
		repo.save(exceedingPerCargo);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
}
