package be.pxl.backend.entity;

import java.util.ArrayList;
import java.util.Date;
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
@Table(name="Sensor_usage")
public class SensorUsage {
	
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int sensor_usage_id;
	@OneToOne
	private Employee employee;
	@ManyToOne
	private Sensor sensor;
	private Date employee_start;
	private Date employee_stop;
	
	@OneToMany(mappedBy="sensor_usage")
	private List<Cargo> cargos = new ArrayList<Cargo>();
	@OneToMany(mappedBy="sensor_usage")
	private List<SensorData> sensorData = new ArrayList<SensorData>();

	public int getSensor_usage_id() {
		return sensor_usage_id;
	}

	public void setSensor_usage_id(int sensor_usage_id) {
		this.sensor_usage_id = sensor_usage_id;
	}

	public Employee getEmployee() {
		return employee;
	}

	public void setEmployee(Employee employee) {
		this.employee = employee;
	}

	public Sensor getSensor() {
		return sensor;
	}

	public void setSensor(Sensor sensor) {
		this.sensor = sensor;
	}

	public Date getEmployee_start() {
		return employee_start;
	}

	public void setEmployee_start(Date employee_start) {
		this.employee_start = employee_start;
	}

	public Date getEmployee_stop() {
		return employee_stop;
	}

	public void setEmployee_stop(Date employee_stop) {
		this.employee_stop = employee_stop;
	}
}
