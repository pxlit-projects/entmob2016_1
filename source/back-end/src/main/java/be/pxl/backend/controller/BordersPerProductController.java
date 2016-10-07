package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.BordersPerProduct;
import be.pxl.backend.service.BordersPerProductService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(this.BORDERSPERPRODUCT_BASE_URL)
public class BordersPerProductController {

	public static final String BORDERSPERPRODUCT_BASE_URL = "/bordersperproducts";
	
	@Autowired
	private IBordersPerProductService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public BordersPerProduct getBordersPerProductById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<BordersPerProduct> getAllBordersPerProducts() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{BordersPerProduct}", method=RequestMethod.POST)
	public void addBordersPerProduct(@RequestBody BordersPerProduct bordersPerProduct) {
		service.persist(bordersPerProduct);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteBordersPerProduct(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateBordersPerProduct(@PathVariable("id") int id, @RequestBody BordersPerProduct BordersPerProduct) {
		service.update(id, BordersPerProduct);
	}
}
