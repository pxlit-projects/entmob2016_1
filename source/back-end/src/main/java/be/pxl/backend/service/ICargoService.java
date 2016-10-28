package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.entity.Product;

public interface ICargoService {

	public Cargo find(int id);
	
	public List<Cargo> all();
	
	public void persist(Cargo cargo);
	
	public void delete(int id);

}
