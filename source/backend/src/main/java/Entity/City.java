package Entity;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class City {

	@Id
	private String postal_code;
	private String city;
	
	public String getPostal_code() {
		return postal_code;
	}
	public void setPostal_code(String postal_code) {
		this.postal_code = postal_code;
	}
	public String getCity() {
		return city;
	}
	public void setCity(String city) {
		this.city = city;
	}
	
	
}
