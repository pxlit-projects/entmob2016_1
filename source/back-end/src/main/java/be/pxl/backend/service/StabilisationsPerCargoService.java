package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.backend.entity.StabilisationPerCargo;
import be.pxl.backend.repository.StabilisationsPerCargoRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class StabilisationsPerCargoService implements IStabilisationsPerCargoService {

	@Autowired
	private StabilisationsPerCargoRepository repo;
	
	public StabilisationPerCargo find(int id) {
		return repo.findOne(id);
	}
	
	public List<StabilisationPerCargo> all() {
		return repo.findAll();
	}
	
	public void persist(StabilisationPerCargo stabilisationPerCargo) {
		repo.save(stabilisationPerCargo);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}

}
