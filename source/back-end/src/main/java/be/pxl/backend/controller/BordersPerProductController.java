package be.pxl.backend.controller;

import java.util.List;

import be.pxl.backend.entity.BordersPerProductPK;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.BordersPerProduct;
import be.pxl.backend.service.BordersPerProductService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(BordersPerProductController.BORDERSPERPRODUCT_BASE_URL)
public class BordersPerProductController {

	public static final String BORDERSPERPRODUCT_BASE_URL = "/bordersperproducts";
	
	@Autowired
	private IBordersPerProductService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public BordersPerProduct getBordersPerProductById(@PathVariable("id") BordersPerProductPK id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<BordersPerProduct> getAllBordersPerProducts() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{BordersPerProduct}", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addBordersPerProduct(@RequestBody BordersPerProduct bordersPerProduct) {
		service.persist(bordersPerProduct);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteBordersPerProduct(@PathVariable("id") BordersPerProductPK id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update", method=RequestMethod.PUT)
	public void updateBordersPerProduct(@RequestBody BordersPerProduct BordersPerProduct) {
		service.update(BordersPerProduct);
	}
}
