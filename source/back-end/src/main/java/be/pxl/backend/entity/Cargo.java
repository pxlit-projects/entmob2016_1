package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import org.hibernate.annotations.*;
import org.hibernate.annotations.CascadeType;
import java.util.List;
import javax.persistence.*;
import javax.persistence.Entity;
import javax.persistence.Table;

@Entity
@Table(name="cargos")
public class Cargo {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int cargo_id;
	private int sensor_id;
	private float weight;
	@OneToMany(mappedBy="cargo")
    @Cascade(CascadeType.ALL)
    @JsonManagedReference(value = "cargos_exceedings")
	private List<ExceedingPerCargo> exceedings;
    @OneToMany(mappedBy="cargo")
    @Cascade(CascadeType.ALL)
    @JsonManagedReference(value = "cargos_borders")
    private List<CargoBorder> borders;
	
	public Cargo(int sensor_id, float weight) {
		this.sensor_id = sensor_id;
		this.weight = weight;
	}
	
	public Cargo() {}

	public int getCargo_id () {
		return cargo_id;
	}
	public int getSensor_id () {
		return sensor_id;
	}
	public float getWeight () {
		return weight;
	}
	public List<ExceedingPerCargo> getExceedings () {
		return exceedings;
	}
	public List<CargoBorder> getBorders() { return borders; }

}
