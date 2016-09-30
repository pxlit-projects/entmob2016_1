package Entity;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class Sensor {

	@Id
	private int sensor_id;
	private String sensor_name;
	private int employee_id;
	private Date employee_start;
	private Date employee_stop;
	private String status;
	
	public int getSensor_id() {
		return sensor_id;
	}
	public void setSensor_id(int sensor_id) {
		this.sensor_id = sensor_id;
	}
	public String getSensor_name() {
		return sensor_name;
	}
	public void setSensor_name(String sensor_name) {
		this.sensor_name = sensor_name;
	}
	public int getEmployee_id() {
		return employee_id;
	}
	public void setEmployee_id(int employee_id) {
		this.employee_id = employee_id;
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
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
}
