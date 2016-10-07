package be.pxl.backend.entity;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

@Entity
@Table(name="Cargos")
public class Cargo {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int cargo_id;
	@ManyToOne
	private SensorUsage sensor_usage;
	@ManyToOne
	private Employee employee;
	@ManyToOne
	private Destination destination;
	private float weight;
	@OneToMany(mappedBy="cargo")
	private List<ProductPerCargo> productsPerCargos = new ArrayList<ProductPerCargo>();
	@OneToMany(mappedBy="cargo")
	private List<ExceedingsPerCargo> ExceedingsPerCargos = new ArrayList<ExceedingsPerCargo>();
	
	public int getCargo_id() {
		return cargo_id;
	}
	public void setCargo_id(int cargo_id) {
		this.cargo_id = cargo_id;
	}
	public SensorUsage getSensor_usage() {
		return sensor_usage;
	}
	public void setSensor_usage(SensorUsage sensor_usage) {
		this.sensor_usage = sensor_usage;
	}
	public void setProductsPerCargos(List<ProductPerCargo> productsPerCargos) {
		this.productsPerCargos = productsPerCargos;
	}
	public void setExceedingsPerCargos(List<ExceedingsPerCargo> exceedingsPerCargos) {
		ExceedingsPerCargos = exceedingsPerCargos;
	}
	public Employee getEmployee() {
		return employee;
	}
	public void setEmployee(Employee employee) {
		this.employee = employee;
	}
	public Destination getDestination() {
		return destination;
	}
	public void setDestination(Destination destination) {
		this.destination = destination;
	}
	public float getWeight() {
		return weight;
	}
	public void setWeight(float weight) {
		this.weight = weight;
	}
	
	
}
