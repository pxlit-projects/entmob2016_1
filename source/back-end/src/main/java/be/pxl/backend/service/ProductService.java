package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.backend.entity.Employee;
import be.pxl.backend.entity.Product;
import be.pxl.backend.repository.ProductRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class ProductService implements IProductService {

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
		Product product = repo.findOne(id);
		product.setStatus(false);
		this.update(product);
	}
	
	public void update(Product product) {
		Product p = repo.findOne(product.getProduct_id());
		p.copy(product);
		repo.save(p);
	}
	
}
