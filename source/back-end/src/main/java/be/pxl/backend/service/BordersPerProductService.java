package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import be.pxl.backend.entity.BordersPerProduct;
import be.pxl.backend.repository.BordersPerProductRepository;

@Component
public class BordersPerProductService {

	@Autowired
	private BordersPerProductRepository repo;
	
	public BordersPerProduct find(int id) {
		return repo.findOne(id);
	}
	
	public List<BordersPerProduct> all() {
		return repo.findAll();
	}
	
	public void persist(BordersPerProduct bordersPerProduct) {
		repo.save(bordersPerProduct);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
	public void update(int id, BordersPerProduct bordersPerProduct) {
		this.delete(id);
		this.persist(bordersPerProduct);
	}
	
}
