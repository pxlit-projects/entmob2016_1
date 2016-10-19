package be.pxl.backend.service;

import java.util.List;

import be.pxl.backend.entity.BordersPerProductPK;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.BordersPerProduct;
import be.pxl.backend.repository.BordersPerProductRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class BordersPerProductService implements IBordersPerProductService {

	@Autowired
	private BordersPerProductRepository repo;
	
	public BordersPerProduct find(BordersPerProductPK id) {
		return repo.findOne(id);
	}
	
	public List<BordersPerProduct> all() {
		return repo.findAll();
	}
	
	public void persist(BordersPerProduct bordersPerProduct) {
		repo.save(bordersPerProduct);
	}
	
	public void delete(BordersPerProductPK id) {
		repo.delete(id);
	}
	
	public void update(BordersPerProduct bordersPerProduct) {
		BordersPerProduct bpp = repo.findOne(bordersPerProduct.getPK());
		bpp.copy(bordersPerProduct);
		repo.save(bpp);
	}
	
}
