package be.pxl.backend.service;

import java.util.List;

import be.pxl.backend.entity.Product;
import be.pxl.backend.repository.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.repository.CargoRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class CargoService implements ICargoService {

	@Autowired
	private CargoRepository repo;
	
	@Autowired
    private ProductRepository productRepo;
	
	public Cargo find(int id) {
		return repo.findOne(id);
	}
	
	public List<Cargo> all() {
		return repo.findAll();
	}
	
	public void persist(Cargo cargo) {
		repo.save(cargo);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
}
