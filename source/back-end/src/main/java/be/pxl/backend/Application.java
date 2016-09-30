package be.pxl.backend;
import java.util.List;

import org.springframework.boot.SpringApplication;
import org.springframework.context.ConfigurableApplicationContext;

import be.pxl.backend.dao.BordersPerProductDAO;
import be.pxl.backend.dao.BordersPerProductDAOImpl;
import be.pxl.backend.entity.BordersPerProduct;

public class Application {

	public static void main(String[] args) {
		ConfigurableApplicationContext ctx = SpringApplication.run(AppConfig.class, args);
		BordersPerProductDAO dao = ctx.getBean("BordersPerProductRepository", BordersPerProductDAO.class);
		List<BordersPerProduct> bpps = dao.getBorderPerProductByProductId(1);
		
		for (BordersPerProduct bordersPerProduct : bpps) {
			System.out.println(bordersPerProduct.getBorder_value_number());
		}
	}
	
}
