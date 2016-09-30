<<<<<<< HEAD:source/back-end/src/main/java/be/pxl/backend/entity/Sensor.java
package be.pxl.backend.entity;

=======
package Entity;
import java.util.ArrayList;
>>>>>>> 735398f7298d92d05c7a41788bf20773da38ef35:source/back-end/src/main/java/Entity/Sensor.java
import java.util.Date;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name="Sensors")
public class Sensor {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int sensor_id;
	private String sensor_name;
	private Employee employee;
	private Date employee_start;
	private Date employee_stop;
	private String status;
	@OneToMany(mappedBy="sensor")
	private ArrayList<Cargo> cargos = new ArrayList<Cargo>();
	
	
	public ArrayList<Cargo> getCargos() {
		return cargos;
	}
	public void setCargos(ArrayList<Cargo> cargos) {
		this.cargos = cargos;
	}
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
	public Employee getEmployee() {
		return employee;
	}
	public void setEmployee(Employee employee) {
		this.employee = employee;
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
