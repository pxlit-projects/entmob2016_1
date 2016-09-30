package be.pxl.backend.entity;

import java.sql.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Stabilisations_per_cargo")
public class StabilisationsPerCargo {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int stabilisations_per_cargo_id;
	private ExceedingsPerCargo exceedingsPerCargo;
	private Date time;
	
	public int getStabilisations_per_cargo_id() {
		return stabilisations_per_cargo_id;
	}
	public void setStabilisations_per_cargo_id(int stabilisations_per_cargo_id) {
		this.stabilisations_per_cargo_id = stabilisations_per_cargo_id;
	}
	public ExceedingsPerCargo getExceedingsPerCargo() {
		return exceedingsPerCargo;
	}
	public void setExceedingsPerCargo(ExceedingsPerCargo exceedingsPerCargo) {
		this.exceedingsPerCargo = exceedingsPerCargo;
	}
	public Date getTime() {
		return time;
	}
	public void setTime(Date time) {
		this.time = time;
	}
	
	
}
