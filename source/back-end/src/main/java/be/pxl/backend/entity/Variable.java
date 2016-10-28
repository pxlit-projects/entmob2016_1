package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonManagedReference;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name="Variables")
public class Variable {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int variable_id;
	private String description;
    @OneToMany(mappedBy = "variable")
    @JsonManagedReference
	@JsonIgnore
	private List<BorderPerProduct> borders = new ArrayList<BorderPerProduct>();
    
	public int getVariable_id() {
		return variable_id;
	}
	public String getDescription() {
		return description;
	}
	
	public void copy(Variable variable) {
		this.description = variable.description;
	}
}
