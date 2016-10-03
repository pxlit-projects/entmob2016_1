package be.pxl.backend;

import org.springframework.boot.SpringApplication;
import org.springframework.context.ConfigurableApplicationContext;
import be.pxl.backend.entity.Product;
import be.pxl.backend.repository.ProductRepository;

public class Application {

	public static void main (String[] args) {
		ConfigurableApplicationContext ctx = SpringApplication.run(Application.class, args);
		ProductRepository repo = ctx.getBean(ProductRepository.class);
		Product product = new Product();
		product.setDescription("HDD");
	}
}
