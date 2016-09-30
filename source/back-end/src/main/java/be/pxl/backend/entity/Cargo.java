package be.pxl.backend.entity;

import java.util.ArrayList;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;

import javax.persistence.Table;

@Entity
@Table(name="Cargos")
public class Cargo {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int cargo_id;
	@ManyToOne
	private Sensor sensor;
	@ManyToOne
	private Employee employee;
	@ManyToOne
	private Destination destination;
	private float weight;
	@OneToMany(mappedBy="cargo")
	private ArrayList<ProductPerCargo> productsPerCargos = new ArrayList<ProductPerCargo>();
	
	private ArrayList<ExceedingsPerCargo> ExceedingsPerCargos = new ArrayList<ExceedingsPerCargo>();
	
	public ArrayList<ProductPerCargo> getProductsPerCargos() {
		return productsPerCargos;
	}
	public void setProductsPerCargos(ArrayList<ProductPerCargo> productsPerCargos) {
		this.productsPerCargos = productsPerCargos;
	}
	public ArrayList<ExceedingsPerCargo> getExceedingsPerCargos() {
		return ExceedingsPerCargos;
	}
	public void setExceedingsPerCargos(ArrayList<ExceedingsPerCargo> exceedingsPerCargos) {
		ExceedingsPerCargos = exceedingsPerCargos;
	}
	public int getCargo_id() {
		return cargo_id;
	}
	public void setCargo_id(int cargo_id) {
		this.cargo_id = cargo_id;
	}
	public Sensor getSensor() {
		return sensor;
	}
	public void setSensor(Sensor sensor) {
		this.sensor = sensor;
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
