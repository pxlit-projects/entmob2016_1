package be.pxl.backend.entity;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Variables")
public class Variable {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int variable_id;
	private String description;
	
	public int getVariable_id() {
		return variable_id;
	}
	public void setVariable_id(int variable_id) {
		this.variable_id = variable_id;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	
	public void copy(Variable variable) {
		this.description = variable.description;
	}
}
