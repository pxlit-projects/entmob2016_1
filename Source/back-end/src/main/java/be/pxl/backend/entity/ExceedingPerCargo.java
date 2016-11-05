package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import javax.persistence.*;
import javax.persistence.Entity;
import javax.persistence.Table;
import java.sql.Timestamp;
import java.util.Date;

@Entity
@Table(name="exceeding_per_cargo")
public class ExceedingPerCargo {
	
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int exceeding_per_cargo_id;
	@ManyToOne
    @JsonBackReference(value = "cargos_exceedings")
	private Cargo cargo;
	@ManyToOne
	private Variable variable;
	private float value;
    private Timestamp time = new Timestamp(new Date().getTime());
    
	public double getValue() {
		return value;
	}
	public int getExceeding_per_cargo_id() {
		return exceeding_per_cargo_id;
	}
	public Variable getVariable() {
		return variable;
	}
	public Timestamp getTime() { return time; }
	
}
