package be.pxl.backend.integration;

import be.pxl.backend.entity.Employee;
import be.pxl.backend.repository.EmployeeRepository;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;
import java.util.Arrays;
import java.util.List;
import static be.pxl.backend.builder.EmployeeBuilder.*;
import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.Assert.*;

@RunWith(SpringRunner.class)
@SpringBootTest
public class EmployeeRepositoryIntegrationTest {
    
    @Autowired
    private EmployeeRepository repo;
    
    @Before
    public void deleteAll() {
        repo.deleteAll();
    }
    
    @Test
    public void test_get_employee_by_username() {
        Employee e1 = anEmployee()
                .withUsername("kstrijbos")
                .withName("Kevin")
                .withSurName("Strijbos")
                .withPassWord("gsbFsdpT")
                .withSalt("AAAAA")
                .build();
        Employee e2 = anEmployee()
                .withUsername("jvermeulen")
                .withName("Joske")
                .withSurName("Vermeulen")
                .withPassWord("gsbFsdpT")
                .withSalt("AAAAA")
                .build();
        
        repo.save(Arrays.asList(e1, e2));
        
        Employee employee = repo.getEmployeeByUsername("kstrijbos");
        
        assertThat(employee.getUsername().equals("kstrijbos"));
    }
    
    @Test
    public void test_delete_employee() {
        Employee e1 = anEmployee()
                .withUsername("kstrijbos")
                .withName("Kevin")
                .withSurName("Strijbos")
                .withPassWord("gsbFsdpT")
                .withSalt("AAAAA")
                .build();
        Employee e2 = anEmployee()
                .withUsername("jvermeulen")
                .withName("Joske")
                .withSurName("Vermeulen")
                .withPassWord("gsbFsdpT")
                .withSalt("AAAAA")
                .build();
        
        repo.save(Arrays.asList(e1,e2));
        List<Employee> employees = repo.findAll();
        int employee_id = employees.get(employees.size()-1).getEmployee_id();
        repo.delete(employee_id);
        
        assertThat(repo.findAll().get(0).equals("kstrijbos"));
    }
    
}