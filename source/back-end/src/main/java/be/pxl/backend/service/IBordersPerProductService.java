package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.BordersPerProduct;

public interface IBordersPerProductService {

	public BordersPerProduct find(int id);
	
	public List<BordersPerProduct> all();
	
	public void persist(BordersPerProduct bordersPerProduct);
	
	public void delete(int id);
	
	public void update(BordersPerProduct bordersPerProduct);
	
}
