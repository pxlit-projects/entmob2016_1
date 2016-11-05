package be.pxl.backend.representation;

import be.pxl.backend.security.user.Role;
import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;

public class EmployeeR {
    
    private int employee_id;
    private String username;
    private String password;
    private String salt;
    private String surName;
    private String name;
    private boolean status;
    private Role clearance = Role.ROLE_USER;
    
    public static EmployeeR of(int employee_id, String username, String password, String salt, String surName, String name, boolean status, Role clearance) {
        return new EmployeeR(employee_id, username, password, salt, surName, name, status, clearance);
    }
    
    @JsonCreator
    private EmployeeR(@JsonProperty("employee_id")int employee_id, @JsonProperty("username")String username, @JsonProperty("password")String password,
                      @JsonProperty("salt")String salt, @JsonProperty("surName")String surName, @JsonProperty("name")String name,
                      @JsonProperty("status")boolean status, @JsonProperty("clearance")Role clearance) {
        this.employee_id = employee_id;
        this.username = username;
        this.password = password;
        this.salt = salt;
        this.surName = surName;
        this.name = name;
        this.status = status;
        this.clearance = clearance;
    }
    
    public int getEmployee_id() { return employee_id; }
    public String getUsername() { return username; }
    public String getPassword() { return password; }
    public String getSalt() { return salt; }
    public String getSurName() { return surName; }
    public String getName() { return name; }
    public boolean getStatus() { return status; }
    public Role getClearance() { return  clearance; }
    
    public String toString() {
        return "EmployeeR{" +
                "employee_id='" + employee_id + '\'' +
                ", username='" + username + '\'' +
                ", password='" + password + '\'' +
                ", salt='" + salt + '\'' +
                ", surname='" + surName + '\'' +
                ", name='" + name + '\'' +
                ", status='" + status + '\'' +
                ", clearance='" + clearance + '\'' +
                '}';
    }
    
}
