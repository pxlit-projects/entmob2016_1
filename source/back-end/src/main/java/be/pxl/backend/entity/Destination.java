package be.pxl.backend.entity;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

@Entity
@Table(name="Destinations")
public class Destination {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int destination_id;
	@OneToOne
	private City city;
	private String street;
	private String housenr;
	private String description;
	
	public int getDestination_id() {
		return destination_id;
	}
	public void setDestination_id(int destination_id) {
		this.destination_id = destination_id;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public City getCity() {
		return city;
	}
	public void setCity(City city) {
		this.city = city;
	}
	public String getStreet() {
		return street;
	}
	public void setStreet(String street) {
		this.street = street;
	}
	public String getHousenr() {
		return housenr;
	}
	public void setHousenr(String housenr) {
		this.housenr = housenr;
	}
	
	
}
