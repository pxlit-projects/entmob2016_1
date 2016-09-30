package be.pxl.backend.dao;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

import org.springframework.stereotype.Repository;
import be.pxl.backend.entity.BordersPerProduct;

@Repository("BordersPerProductRepository")
public class BordersPerProductDAOImpl implements BordersPerProductDAO {

	private EntityManagerFactory emf;
	
	@PersistenceUnit
	public void setEntityManagerFactory(EntityManagerFactory emf) {
		this.emf = emf;
	}
	
	public List<BordersPerProduct> getBorderPerProductByProductId(int id) {
		EntityManager em = emf.createEntityManager();
		EntityTransaction tx = em.getTransaction();
		
		tx.begin();
		List<BordersPerProduct> bbps = (List<BordersPerProduct>) em.find(BordersPerProduct.class, id);
		tx.commit();
		em.close();
		return bbps;
	}

	public void updateBordersPerProduct(BordersPerProduct bpp) {
	}

	public void deleteBordersPerProduct(BordersPerProduct bpp) {
	}

}
