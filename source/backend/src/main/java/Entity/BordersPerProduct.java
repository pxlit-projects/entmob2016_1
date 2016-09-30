package Entity;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class BordersPerProduct {

	@Id
	private int product_id;
	private int border_value_variable;
	private float border_value_number;
	
	public int getProduct_id() {
		return product_id;
	}
	public void setProduct_id(int product_id) {
		this.product_id = product_id;
	}
	public int getBorder_value_variable() {
		return border_value_variable;
	}
	public void setBorder_value_variable(int border_value_variable) {
		this.border_value_variable = border_value_variable;
	}
	public float getBorder_value_number() {
		return border_value_number;
	}
	public void setBorder_value_number(float border_value_number) {
		this.border_value_number = border_value_number;
	}
	
}
