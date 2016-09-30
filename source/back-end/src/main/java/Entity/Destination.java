package Entity;

import java.util.ArrayList;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name="Destinations")
public class Destination {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int destination_id;
	private String description;
	private City city;
	private String street;
	private String housenr;
	private int contact_id;
	@OneToMany(mappedBy="destination")
	private ArrayList<Sensor> sensors = new ArrayList<Sensor>();
	
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
	public int getContact_id() {
		return contact_id;
	}
	public void setContact_id(int contact_id) {
		this.contact_id = contact_id;
	}
	
	
}
