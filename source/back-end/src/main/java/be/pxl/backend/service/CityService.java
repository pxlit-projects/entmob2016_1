package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.City;
import be.pxl.backend.repository.CityRepository;

@Service
public class CityService implements ICityService {

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
	
	public void update(City city) {
		repo.save(city);
	}
	
}
