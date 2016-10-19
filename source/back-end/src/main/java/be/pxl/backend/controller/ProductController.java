package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.Product;
import be.pxl.backend.service.ProductService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(ProductController.PRODUCT_BASE_URL)
public class ProductController {
	public static final String PRODUCT_BASE_URL = "/products";
	@Autowired
	private IProductService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Product getProductById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Product> getAllProducts() {
		return service.all();
	}
	
	@RequestMapping(value = "/add", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addProduct(@RequestBody Product product) {
		service.persist(product);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteProduct(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update", method=RequestMethod.PUT)
	public void updateProduct(@RequestBody Product product) {
		service.update(product);
	}
}
