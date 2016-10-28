package be.pxl.backend.entity;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Cities")
public class City {

	@Id
	private String postal_code;
	private String city_name;
	
	public String getPostal_code() {
		return postal_code;
	}
	public void setPostal_code(String postal_code) {
		this.postal_code = postal_code;
	}
	public String getCity() {
		return city_name;
	}
	public void setCity(String city) {
		this.city_name = city;
	}
	
	public void copy(City city) {
		this.city_name = city.city_name;
	}
}
