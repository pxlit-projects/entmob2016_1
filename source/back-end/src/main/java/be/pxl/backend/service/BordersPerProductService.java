package be.pxl.backend.service;

import java.util.List;

import be.pxl.backend.entity.BorderPerProductPK;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.BorderPerProduct;
import be.pxl.backend.repository.BordersPerProductRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class BordersPerProductService implements IBordersPerProductService {

	@Autowired
	private BordersPerProductRepository repo;
	
	public BorderPerProduct find(BorderPerProductPK id) {
		return repo.findOne(id);
	}
	
	public List<BorderPerProduct> all() {
		return repo.findAll();
	}
	
	public void persist(BorderPerProduct borderPerProduct) {
		repo.save(borderPerProduct);
	}
	
	public void delete(BorderPerProductPK id) {
		repo.delete(id);
	}
	
	public void update(BorderPerProduct borderPerProduct) {
		BorderPerProduct bpp = repo.findOne(borderPerProduct.getPK());
		bpp.copy(borderPerProduct);
		repo.save(bpp);
	}
	
}
