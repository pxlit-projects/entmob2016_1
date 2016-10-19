package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.BordersPerProduct;
import be.pxl.backend.entity.BordersPerProductPK;

public interface IBordersPerProductService {

	public BordersPerProduct find(BordersPerProductPK id);
	
	public List<BordersPerProduct> all();
	
	public void persist(BordersPerProduct bordersPerProduct);
	
	public void delete(BordersPerProductPK id);
	
	public void update(BordersPerProduct bordersPerProduct);
	
}
