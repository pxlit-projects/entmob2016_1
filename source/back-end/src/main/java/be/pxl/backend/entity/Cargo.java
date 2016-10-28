package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import org.hibernate.annotations.Cascade;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;

@Entity
@Table(name="Cargos")
public class Cargo {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int cargo_id;
	@ManyToOne
    @JsonManagedReference
	private Destination destination;
    @ManyToOne
    @JsonManagedReference
    private Sensor sensor;
	private float weight;
	@OneToMany(mappedBy="cargo")
    @JsonManagedReference
	private List<ExceedingPerCargo> exceedings = new ArrayList<ExceedingPerCargo>();
    @OneToMany(mappedBy="cargo")
    @JsonManagedReference
    private List<StabilisationPerCargo> stabilisations = new ArrayList<StabilisationPerCargo>();
	@OneToMany(mappedBy = "cargo")
    @JsonManagedReference
    private List<ProductPerCargo> products = new ArrayList<ProductPerCargo>();

	public int getCargo_id() {
		return cargo_id;
	}
	public float getWeight() {
		return weight;
	}
	
}
