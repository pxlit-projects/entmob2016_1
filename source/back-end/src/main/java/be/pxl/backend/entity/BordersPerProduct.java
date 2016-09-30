package be.pxl.backend.entity;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToOne;
import javax.persistence.Table;

@Entity
@Table(name="Borders_per_product")
public class BordersPerProduct {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int product_id;
	@OneToOne
	private Variable variable;
	private float border_value_number;
	
	public int getProduct_id() {
		return product_id;
	}
	public void setProduct_id(int product_id) {
		this.product_id = product_id;
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
	
}
