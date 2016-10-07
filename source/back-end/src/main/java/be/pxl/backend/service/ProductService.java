package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import be.pxl.backend.entity.Employee;
import be.pxl.backend.entity.Product;
import be.pxl.backend.repository.ProductRepository;

@Component
public class ProductService {

	@Autowired
	private ProductRepository repo;
	
	public Product find(int id) {
		return repo.findOne(id);
	}
	
	public List<Product> all() {
		return repo.findAll();
	}
	
	public void persist(Product product) {
		repo.save(product);
	}
	
	public void delete(int id) {
		Product pro = repo.findOne(id);
		pro.setStatus(false);
		this.update(id, pro);
	}
	
	public void update(int id, Product product) {
		repo.delete(id);
		this.persist(product);
	}
	
}