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
    @Column(unique = true)
	private String username;
	private String password;
	private String salt;
	private String surName;
	private String name;
	private Boolean status;
    @Enumerated(EnumType.STRING)
    public Role clearance = Role.ROLE_USER;
    
    public Employee(String username, String password, String salt, String surName, String name) {
        this.username = username;
        this.password = password;
        this.salt = salt;
        this.surName = surName;
        this.name = name;
        this.status = true;
    }
    
    public Employee() {}
    
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
