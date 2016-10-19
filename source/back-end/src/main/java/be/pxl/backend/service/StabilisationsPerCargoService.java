package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;

import be.pxl.backend.entity.StabilisationsPerCargo;
import be.pxl.backend.repository.StabilisationsPerCargoRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class StabilisationsPerCargoService implements IStabilisationsPerCargoService {

	@Autowired
	private StabilisationsPerCargoRepository repo;
	
	public StabilisationsPerCargo find(int id) {
		return repo.findOne(id);
	}
	
	public List<StabilisationsPerCargo> all() {
		return repo.findAll();
	}
	
	public void persist(StabilisationsPerCargo stabilisationsPerCargo) {
		repo.save(stabilisationsPerCargo);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}

}
