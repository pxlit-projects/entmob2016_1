package be.pxl.backend.entity;

import java.io.Serializable;

public class BorderPerProductPK implements Serializable{
	private int product_id;
    private int variable_id;
    
	public int getProduct_id() {
		return product_id;
	}
	public void setProduct_id(int product_id) {
		this.product_id = product_id;
	}
	public int getVariable_id() {
		return variable_id;
	}
	public void setVariable_id(int variable_id) {
		this.variable_id = variable_id;
	}
	
}
