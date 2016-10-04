package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import be.pxl.backend.entity.City;
import be.pxl.backend.repository.CityRepository;

@Component
public class CityService {

	@Autowired
	private CityRepository repo;
	
	public City find(String postal) {
		return repo.findOne(postal);
	}
	
	public List<City> all() {
		return repo.findAll();
	}
	
	public void persist(City city) {
		repo.save(city);
	}
	
	public void delete(String postal) {
		repo.delete(postal);
	}
	
	public void update(String postal, City city) {
		this.delete(postal);
		this.persist(city);
	}
	
}
