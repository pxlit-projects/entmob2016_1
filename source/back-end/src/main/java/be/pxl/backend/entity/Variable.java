package be.pxl.backend.entity;

import javax.persistence.*;
import java.util.List;

@Entity
@Table(name="variables")
public class Variable {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int variable_id;
	private String description;
	@OneToMany(mappedBy = "variable")
	private List<ExceedingPerCargo> exceedings;
    @OneToMany(mappedBy = "variable")
    private List<CargoBorder> borders;
    
	public int getVariable_id() {
		return variable_id;
	}
	public String getDescription() {
		return description;
	}
}
