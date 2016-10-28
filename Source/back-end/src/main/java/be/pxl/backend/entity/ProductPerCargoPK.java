package be.pxl.backend.entity;

import java.io.Serializable;

public class ProductPerCargoPK implements Serializable{
		private int product_id;
	    private int cargo_id;
	    
		public int getProduct_id() {
			return product_id;
		}
		public void setProduct_id(int product_id) {
			this.product_id = product_id;
		}
		public int getCargo_id() {
			return cargo_id;
		}
		public void setCargo_id(int cargo_id) {
			this.cargo_id = cargo_id;
		}
	    
}
