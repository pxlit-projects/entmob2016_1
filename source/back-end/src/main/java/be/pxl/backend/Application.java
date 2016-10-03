package be.pxl.backend;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import be.pxl.backend.repository.ProductRepository;
import be.pxl.backend.rest.ProductController;

public class Application {

	public static void main (String[] args) {
		ConfigurableApplicationContext ctx = SpringApplication.run(AppConfig.class, args);
	}
	
}
