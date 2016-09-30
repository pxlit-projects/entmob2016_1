package be.pxl.backend.entity;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Exceedings_per_cargo")
public class ExceedingsPerCargo {
	
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int exceeding_per_cargo_id;
	private Cargo cargo;
	private Variable variable;
	
	public int getExceeding_per_cargo_id() {
		return exceeding_per_cargo_id;
	}
	public void setExceeding_per_cargo_id(int exceeding_per_cargo_id) {
		this.exceeding_per_cargo_id = exceeding_per_cargo_id;
	}
	public Cargo getCargo() {
		return cargo;
	}
	public void setCargo(Cargo cargo) {
		this.cargo = cargo;
	}
	public Variable getVariable() {
		return variable;
	}
	public void setVariable(Variable variable) {
		this.variable = variable;
	}
	
}
