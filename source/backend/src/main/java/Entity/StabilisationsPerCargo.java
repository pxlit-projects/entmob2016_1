package Entity;

import java.sql.Date;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class StabilisationsPerCargo {

	@Id
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
