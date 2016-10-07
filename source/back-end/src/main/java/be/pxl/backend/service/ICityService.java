package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.City;

public interface ICityService {

	public City find(String postal);
	
	public List<City> all();
	
	public void persist(City city);
	
	public void delete(String postal);
	
	public void update(String postal, City city);
	
}

