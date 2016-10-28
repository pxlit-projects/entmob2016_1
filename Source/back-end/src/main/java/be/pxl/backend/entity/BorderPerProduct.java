package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import org.hibernate.annotations.Cascade;

import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.ManyToOne;
import javax.persistence.MapsId;
import javax.persistence.Table;

@Entity
@Table(name="Borders_per_product")
public class BorderPerProduct {

	@EmbeddedId
	private BorderPerProductPK id;
	@MapsId("product_id")
	@ManyToOne
	@JsonBackReference
    @Cascade (value={org.hibernate.annotations.CascadeType.ALL})
	private Product product;
	@MapsId("variable_id")
	@ManyToOne
    @JsonBackReference
	private Variable variable;
	private float border_value_number;
	
	public BorderPerProductPK getPK() { return id; }
	public float getBorder_value_number() {
		return border_value_number;
	}
	
	public void copy(BorderPerProduct bpp) {
		this.product = bpp.product;
		this.variable = bpp.variable;
		this.border_value_number = bpp.border_value_number;
	}
}
