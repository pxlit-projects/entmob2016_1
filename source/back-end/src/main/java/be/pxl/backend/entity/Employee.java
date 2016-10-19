package be.pxl.backend.entity;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import org.hibernate.annotations.NamedQuery;
import org.springframework.data.jpa.repository.Query;

@Entity
@Table(name="Employees")
public class Employee {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int employee_id;
	private String username;
	private String password;
	private String salt;
	private String surName;
	private String name;
	private String street;
	private String houseNr;
	@OneToOne
	private City city;
	private Date date_employment;
	private String mobile_phone;
	private String telephone_number;
	private String email;
	private String sex;
	private Boolean status;
	@OneToMany(mappedBy="employee")
	@JsonManagedReference
	private List<Login> logins = new ArrayList<Login>();
	
	public List<Login> getLogins() {
		return logins;
	}
	public void setLogins(List<Login> logins) {
		this.logins = logins;
	}
	public Boolean getStatus() {
		return status;
	}
	public void setStatus(Boolean status) {
		this.status = status;
	}
	public int getEmployee_id() {
		return employee_id;
	}
	public void setEmployee_id(int employee_id) {
		this.employee_id = employee_id;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public String getSalt() {
		return salt;
	}
	public void setSalt(String salt) {
		this.salt = salt;
	}
	public String getSurName() {
		return surName;
	}
	public void setSurName(String surName) {
		this.surName = surName;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getStreet() {
		return street;
	}
	public void setStreet(String street) {
		this.street = street;
	}
	public String getHouseNr() {
		return houseNr;
	}
	public void setHouseNr(String houseNr) {
		this.houseNr = houseNr;
	}
	public City getCity() {
		return city;
	}
	public void setCity(City city) {
		this.city = city;
	}
	public Date getDate_employment() {
		return date_employment;
	}
	public void setDate_employment(Date date_employment) {
		this.date_employment = date_employment;
	}
	public String getMobile_phone() {
		return mobile_phone;
	}
	public void setMobile_phone(String mobile_phone) {
		this.mobile_phone = mobile_phone;
	}
	public String getTelephone_number() {
		return telephone_number;
	}
	public void setTelephone_number(String telephone_number) {
		this.telephone_number = telephone_number;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	
	public void copy(Employee employee) {
		this.username = employee.username;
		this.password = employee.password;
		this.salt = employee.salt;
		this.name = employee.name;
		this.surName = employee.surName;
		this.street = employee.street;
		this.houseNr = employee.houseNr;
		this.city = employee.city;
		this.date_employment = employee.date_employment;
		this.mobile_phone = employee.mobile_phone;
		this.telephone_number = employee.telephone_number;
		this.email = employee.email;
		this.sex = employee.sex;
		this.status = employee.status;
		this.logins = employee.logins;
	}
}
