package be.pxl.backend.entity;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name="Products")
public class Product {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int product_id;
	private String description;
	private boolean status;
	@OneToMany(mappedBy="product")
	private List<ProductPerCargo> products = new ArrayList<ProductPerCargo>();
	public int getProduct_id() {
		return product_id;
	}
	public boolean isStatus() {
		return status;
	}
	public void setStatus(boolean status) {
		this.status = status;
	}
	public void setProduct_id(int product_id) {
		this.product_id = product_id;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	
}
