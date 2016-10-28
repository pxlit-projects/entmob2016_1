package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;

import java.sql.Date;

import javax.persistence.*;

@Entity
@Table(name="Stabilisations_per_cargo")
public class StabilisationPerCargo {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int stabilisations_per_cargo_id;
	@OneToOne
	private ExceedingPerCargo exceedingPerCargo;
	@ManyToOne
	@JsonBackReference
	private Cargo cargo;
	private Date time;
	
	public int getStabilisations_per_cargo_id() {
		return stabilisations_per_cargo_id;
	}
	public void setStabilisations_per_cargo_id(int stabilisations_per_cargo_id) {
		this.stabilisations_per_cargo_id = stabilisations_per_cargo_id;
	}
	public ExceedingPerCargo getExceedingPerCargo () {
		return exceedingPerCargo;
	}
	public void setExceedingPerCargo (ExceedingPerCargo exceedingPerCargo) {
		this.exceedingPerCargo = exceedingPerCargo;
	}
	public Date getTime() {
		return time;
	}
	public void setTime(Date time) {
		this.time = time;
	}
	
	
}
