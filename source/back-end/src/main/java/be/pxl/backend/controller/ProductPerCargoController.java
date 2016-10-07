package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.ProductPerCargo;
import be.pxl.backend.service.ProductPerCargoService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(ProductPerCargoController.PRODUCTPERCARGO_BASE_URL)
public class ProductPerCargoController {
	public static final String PRODUCTPERCARGO_BASE_URL = "/productpercargo";
	@Autowired
	private IProductPerCargoService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public ProductPerCargo getProductPerCargoById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<ProductPerCargo> getAllProductPerCargos() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{productPerCargo}", method=RequestMethod.POST)
	public void addProductPerCargo(@RequestBody ProductPerCargo productPerCargo) {
		service.persist(productPerCargo);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteProductPerCargo(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateProductPerCargo(@PathVariable("id") int id, @RequestBody ProductPerCargo productPerCargo) {
		service.update(id, productPerCargo);
	}
}
