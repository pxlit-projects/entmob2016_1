package Entity;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class ExceedingsPerCargo {
	
	@Id
	private int exceeding_per_cargo_id;
	private int cargo_id;
	private int variable_id;
	
	public int getExceeding_per_cargo_id() {
		return exceeding_per_cargo_id;
	}
	public void setExceeding_per_cargo_id(int exceeding_per_cargo_id) {
		this.exceeding_per_cargo_id = exceeding_per_cargo_id;
	}
	public int getCargo_id() {
		return cargo_id;
	}
	public void setCargo_id(int cargo_id) {
		this.cargo_id = cargo_id;
	}
	public int getVariable_id() {
		return variable_id;
	}
	public void setVariable_id(int variable_id) {
		this.variable_id = variable_id;
	}
	
}
