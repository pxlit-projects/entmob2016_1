package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import org.hibernate.annotations.*;
import javax.persistence.*;
import javax.persistence.Entity;
import javax.persistence.Table;
import java.util.List;

@Entity
@Table(name="sensors")
public class Sensor {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int sensor_id;
	private String sensor_name;
	private boolean status;
	@OneToMany(mappedBy="sensor")
	@Cascade (org.hibernate.annotations.CascadeType.ALL)
	@JsonManagedReference (value = "sensor_data")
	private List<SensorData> data;
	
	public Sensor(String sensorName) {
		this.sensor_name = sensorName;
	}
	
	public Sensor() {}

	public int getSensor_id() {
		return sensor_id;
	}
	public String getSensor_name() {
		return sensor_name;
	}
	public boolean isStatus() {
		return status;
	}
	public List<SensorData> getData() { return data; }

	public void setStatus(boolean status) { this.status = status; }
    
}
