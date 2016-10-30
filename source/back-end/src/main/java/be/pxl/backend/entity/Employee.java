package be.pxl.backend.entity;

import be.pxl.backend.security.user.Role;

import javax.persistence.*;
import javax.persistence.Entity;
import javax.persistence.Table;

@Entity
@Table(name="employees")
public class Employee {

	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private int employee_id;
	private String username;
	private String password;
	private String salt;
	private String surName;
	private String name;
	private Boolean status;
    public Role clearance;
    
    public int getEmployee_id () {
        return employee_id;
    }
    public String getUsername () {
        return username;
    }
    public String getPassword () {
        return password;
    }
    public String getSalt () {
        return salt;
    }
    public String getSurName () {
        return surName;
    }
    public String getName () {
        return name;
    }
    public Boolean getStatus () {
        return status;
    }
    public Role getClearance() { return clearance; }
    
    public void setStatus(boolean status) { this.status = status; }
	
}
