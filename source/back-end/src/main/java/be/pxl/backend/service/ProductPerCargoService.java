package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import be.pxl.backend.entity.ProductPerCargo;
import be.pxl.backend.repository.ProductPerCargoRepository;

@Component
public class ProductPerCargoService {

	@Autowired
	private ProductPerCargoRepository repo;
	
	public ProductPerCargo find(int id) {
		return repo.findOne(id);
	}
	
	public List<ProductPerCargo> all() {
		return repo.findAll();
	}
	
	public void persist(ProductPerCargo productPerCargo) {
		repo.save(productPerCargo);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
	public void update(int id, ProductPerCargo productPerCargo) {
		this.delete(id);
		this.persist(productPerCargo);
	}
	
}
