package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Product;
import be.pxl.backend.service.ProductService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping("/products")
public class ProductController {
	
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
	
	@RequestMapping(value = "/add/{product}", method=RequestMethod.POST)
	public void addProduct(@RequestBody Product product) {
		service.persist(product);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteProduct(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateProduct(@PathVariable("id") int id, @RequestBody Product product) {
		service.update(id, product);
	}
}
