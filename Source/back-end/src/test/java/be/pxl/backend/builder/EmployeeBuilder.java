package be.pxl.backend.builder;

import be.pxl.backend.entity.Employee;

public class EmployeeBuilder {
    
    private String username;
    private String password;
    private String salt;
    private String surName;
    private String name;
    
    public Employee build() {
        return new Employee(username, password, salt, surName, name);
    }
    
    public static EmployeeBuilder anEmployee() {
        return new EmployeeBuilder();
    }
    
    public EmployeeBuilder withUsername (String username) {
        this.username = username;
        return this;
    }
    
    public EmployeeBuilder withPassWord (String password) {
        this.password = password;
        return this;
    }
    
    public EmployeeBuilder withSalt (String salt) {
        this.salt = salt;
        return this;
        
    }
    
    public EmployeeBuilder withSurName (String surName) {
        this.surName = surName;
        return this;
    }
    
    public EmployeeBuilder withName (String name) {
        this.name = name;
        return this;
    }
    
}
