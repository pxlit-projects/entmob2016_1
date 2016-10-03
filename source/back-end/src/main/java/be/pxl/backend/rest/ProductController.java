package be.pxl.backend.rest;

import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Product;
import be.pxl.backend.repository.ProductRepository;

@RestController
@RequestMapping("/products")
public class ProductController {
	
	private ProductRepository $repo;

	public ProductController(ProductRepository repo) {
		$repo = repo;
	}
	
	public void setRepo(ProductRepository repo) {
		$repo = repo;
	}
	
	@RequestMapping(value = "{id}", method = RequestMethod.GET, produces="application/json")
	Product getProductById(@PathVariable("id") int id) {
		if ($repo != null && $repo.exists(id)) {
			return $repo.findOne(id);
		} else {
			return null;
		}
	}
}
