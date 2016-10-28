package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonManagedReference;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;

@Entity
@Table(name="Products")
public class Product {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int product_id;
    @OneToMany(mappedBy = "product")
    @JsonManagedReference
    private List<BorderPerProduct> borders = new ArrayList<BorderPerProduct>();
	private String title;
	private String description;
	private boolean status;
	@OneToMany(mappedBy = "product")
	private List<ProductPerCargo> cargos = new ArrayList<ProductPerCargo>();
    
	public int getProduct_id() {
		return product_id;
	}
	public String getTitle() { return title; }
	public boolean isStatus() {
		return status;
	}
	public String getDescription() {
		return description;
	}

	public void setStatus(boolean status) { this.status = status; }
	
	public void copy(Product product) {
		this.title = product.title;
		this.description = product.description;
		this.status = product.status;
	}
	
}
