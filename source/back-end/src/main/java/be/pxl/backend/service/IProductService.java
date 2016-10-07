package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Product;

public interface IProductService {

	public Product find(int id);
	
	public List<Product> all();
	
	public void persist(Product product);
	
	public void delete(int id);
	
	public void update(int id, Product product);
	
}
