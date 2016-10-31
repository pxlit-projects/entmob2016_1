package be.pxl.backend.controller;

import be.pxl.backend.entity.Employee;
import be.pxl.backend.service.EmployeeService;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;

import java.util.List;

import static be.pxl.backend.builder.EmployeeBuilder.anEmployee;
import static java.util.Arrays.asList;
import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
@SpringBootTest
public class EmployeeControllerTest {
    
    @Autowired
    private MockMvc mockMvc;
    
    @Autowired
    private EmployeeService service;
    
    @Autowired
    private WebApplicationContext context;
    
    private HttpMessageConverter mappingJackson2HttpMessageConverter;
    
    @Autowired
    void setConverters(HttpMessageConverter<?>[] converters) {
        mappingJackson2HttpMessageConverter = asList(converters)
                .stream()
                .filter(hmc -> hmc instanceof MappingJackson2HttpMessageConverter)
                .findAny()
                .get();
        
        assertThat(mappingJackson2HttpMessageConverter)
                .isNotNull()
                .describedAs("the JSON message converter must not be null");
    }
    
    @Before
    public void setUp() throws Exception {
        List<Employee> employees = service.all();
        
        for(Employee employee : employees) {
            service.delete(employee.getEmployee_id());
        }
        
        mockMvc = MockMvcBuilders.webAppContextSetup(context).build();
    }
    
    @Test
    public void test_list_all_employees() throws Exception {
        Employee employee = anEmployee()
                .withUsername("kstrijbos")
                .withName("Kevin")
                .withSalt("AAAAAA")
                .withSurName("Strijbos")
                .withPassWord("gsbFsdpT")
                .build();
        
        service.persist(employee);
        
        List<Employee> employees = service.all();
        
        int employee_id = employees.get(employees.size()-1).getEmployee_id();
        
        mockMvc.perform(get(EmployeeController.EMPLOYEE_BASE_URL + "/all"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8));
    }
    
}