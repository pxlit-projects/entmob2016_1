package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.BorderPerProduct;
import be.pxl.backend.entity.BorderPerProductPK;

public interface IBordersPerProductService {

	public BorderPerProduct find(BorderPerProductPK id);
	
	public List<BorderPerProduct> all();
	
	public void persist(BorderPerProduct borderPerProduct);
	
	public void delete(BorderPerProductPK id);
	
	public void update(BorderPerProduct borderPerProduct);
	
}
