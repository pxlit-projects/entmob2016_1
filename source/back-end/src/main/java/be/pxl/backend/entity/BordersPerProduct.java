package be.pxl.backend.entity;

import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.MapsId;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.PrimaryKeyJoinColumn;
import javax.persistence.Table;

@Entity
@Table(name="Borders_per_product")
public class BordersPerProduct {

	@EmbeddedId
	private BordersPerProductPK id;
	@MapsId("product_id")
	@ManyToOne
	private Product product;
	@MapsId("variable_id")
	@ManyToOne
	private Variable variable;
	private float border_value_number;
	
	public BordersPerProductPK getPK() { return id; }
	public Product getProduct() {
		return product;
	}
	public void setProduct(Product product) {
		this.product = product;
	}
	public Variable getVariable() {
		return variable;
	}
	public void setVariable(Variable variable) {
		this.variable = variable;
	}
	public float getBorder_value_number() {
		return border_value_number;
	}
	public void setBorder_value_number(float border_value_number) {
		this.border_value_number = border_value_number;
	}
	
	public void copy(BordersPerProduct bpp) {
		this.product = bpp.product;
		this.variable = bpp.variable;
		this.border_value_number = bpp.border_value_number;
	}
}
