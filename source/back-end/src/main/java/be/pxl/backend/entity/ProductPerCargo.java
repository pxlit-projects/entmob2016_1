package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.ManyToOne;
import javax.persistence.MapsId;
import javax.persistence.Table;

@Entity
@Table(name="Products_per_cargo")
public class ProductPerCargo {

	@EmbeddedId
	private ProductPerCargoPK Id;
	@MapsId("product_id")
	@ManyToOne
	private Product product;
	@MapsId("cargo_id")
	@ManyToOne
	@JsonIgnore
	private Cargo cargo;
	private int amount;
	
	public Product getProduct() {
		return product;
	}
	public void setProduct(Product product) {
		this.product = product;
	}
	public Cargo getCargo() {
		return cargo;
	}
	public void setCargo(Cargo cargo) {
		this.cargo = cargo;
	}
	public int getAmount() {
		return amount;
	}
	public void setAmount(int amount) {
		this.amount = amount;
	}
	
}
