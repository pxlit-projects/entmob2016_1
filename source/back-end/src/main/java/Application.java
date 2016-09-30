import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.Persistence;

import be.pxl.backend.dao.BordersPerProductDAO;
import be.pxl.backend.dao.BordersPerProductDAOImpl;
import be.pxl.backend.entity.BordersPerProduct;

public class Application {

	public static void main(String[] args) {
		BordersPerProductDAO dao = new BordersPerProductDAOImpl();
		List<BordersPerProduct> bpp = dao.getBorderPerProductByProductId(1);
		System.out.println(bpp.get(0).getBorder_value_number());
	}
	
}
