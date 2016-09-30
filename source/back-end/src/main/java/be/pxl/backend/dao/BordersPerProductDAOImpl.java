package be.pxl.backend.dao;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.Persistence;

import be.pxl.backend.entity.BordersPerProduct;

public class BordersPerProductDAOImpl implements BordersPerProductDAO {

	public List<BordersPerProduct> getBorderPerProductByProductId(int id) {
		return null;
	}

	public void updateBordersPerProduct(BordersPerProduct bpp) {
	}

	public void deleteBordersPerProduct(BordersPerProduct bpp) {
	}

}
