package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.ProductPerCargo;

public interface IProductPerCargoService {

	public ProductPerCargo find(int id);
	
	public List<ProductPerCargo> all();
	
	public void persist(ProductPerCargo productPerCargo);
	
	public void delete(int id);
	
	public void update(int id, ProductPerCargo productPerCargo);
	
}
