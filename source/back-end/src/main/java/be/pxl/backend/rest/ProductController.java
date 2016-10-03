package be.pxl.backend.rest;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Product;
import be.pxl.backend.repository.ProductRepository;

@RestController
@RequestMapping("/products")
public class ProductController {
	
	@Autowired
	private ProductRepository $repo;

	public ProductController(ProductRepository repo) {
		$repo = repo;
	}
	
	public void setRepo(ProductRepository repo) {
		$repo = repo;
	}
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Product getProductById(@PathVariable("id") int id) {
		return $repo.findOne(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Product> getAllProducts() {
		return $repo.findAll();
	}
	
	@RequestMapping(value = "/add/{product}", method=RequestMethod.POST)
	public void addProduct(@PathVariable("product") Product product) {
		$repo.save(product);
	}
}
