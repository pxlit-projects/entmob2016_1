package Entity;

public class Cargo {

	private int cargo_id;
	private int sensor_id;
	private int employee_id;
	private int destination_id;
	private float weight;
	
	public int getCargo_id() {
		return cargo_id;
	}
	public void setCargo_id(int cargo_id) {
		this.cargo_id = cargo_id;
	}
	public int getSensor_id() {
		return sensor_id;
	}
	public void setSensor_id(int sensor_id) {
		this.sensor_id = sensor_id;
	}
	public int getEmployee_id() {
		return employee_id;
	}
	public void setEmployee_id(int employee_id) {
		this.employee_id = employee_id;
	}
	public int getDestination_id() {
		return destination_id;
	}
	public void setDestination_id(int destination_id) {
		this.destination_id = destination_id;
	}
	public float getWeight() {
		return weight;
	}
	public void setWeight(float weight) {
		this.weight = weight;
	}
	
	
}
