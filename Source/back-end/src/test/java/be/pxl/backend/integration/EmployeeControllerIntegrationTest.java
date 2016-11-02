package be.pxl.backend.integration;

import be.pxl.backend.controller.EmployeeController;
import be.pxl.backend.entity.Employee;
import be.pxl.backend.representation.EmployeeR;
import be.pxl.backend.security.user.Role;
import be.pxl.backend.service.IEmployeeService;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.mock.http.MockHttpOutputMessage;
import org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;
import java.io.IOException;
import java.util.List;
import static be.pxl.backend.builder.EmployeeBuilder.*;
import static java.util.Arrays.asList;
import static java.util.Collections.singletonList;
import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.user;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
@SpringBootTest
public class EmployeeControllerIntegrationTest {
    
    private MockMvc mockMvc;
    
    @Autowired
    private IEmployeeService service;
    
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
            service.hardDelete(employee.getEmployee_id());
        }
        
        mockMvc = MockMvcBuilders.webAppContextSetup(context)
                .apply(SecurityMockMvcConfigurers.springSecurity())
                .build();
    }
    
    @Test
    public void test_get_employee_by_id() throws Exception {
        Employee employee = anEmployee()
                .withUsername("kstrijbos")
                .withName("Kevin")
                .withSalt("AAAAAA")
                .withSurName("Strijbos")
                .withPassWord("gsbFsdpT")
                .build();
        
        service.persist(employee);
        
        int employee_id = employee.getEmployee_id();
        
        mockMvc.perform(get(EmployeeController.EMPLOYEE_BASE_URL + "/get/id/" + employee_id)
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        EmployeeR.of(employee_id,
                                "kstrijbos",
                                "gsbFsdpT",
                                "AAAAAA",
                                "Strijbos",
                                "Kevin",
                                true,
                                Role.ROLE_USER)
                )));
    }
    
    @Test
    public void test_get_all_employees() throws Exception {
        Employee employee = anEmployee()
                .withUsername("kstrijbos")
                .withName("Kevin")
                .withSalt("AAAAAA")
                .withSurName("Strijbos")
                .withPassWord("gsbFsdpT")
                .build();
        
        service.persist(employee);
        
        int employee_id = employee.getEmployee_id();
        
        mockMvc.perform(get(EmployeeController.EMPLOYEE_BASE_URL + "/all")
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        singletonList(EmployeeR.of(employee_id,
                                "kstrijbos",
                                "gsbFsdpT",
                                "AAAAAA",
                                "Strijbos",
                                "Kevin",
                                true,
                                Role.ROLE_USER))
                )));
    }
    
    @Test
    public void test_persist_employee_with_admin() throws Exception {
        Employee employee = new Employee();
        service.persist(employee);
        int employee_id = service.all().get(0).getEmployee_id() + 1;
        
        mockMvc.perform(post(EmployeeController.EMPLOYEE_BASE_URL + "/add")
                .with(user("admin").roles("ADMIN"))
                .content(asJson(EmployeeR.of(employee_id, "kstrijbos", "gsbFsdpT", "AAAAAA", "Strijbos", "Kevin", true, Role.ROLE_ADMIN)))
                .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().isCreated());
        
        mockMvc.perform(get(EmployeeController.EMPLOYEE_BASE_URL + "/get/id/" + employee_id)
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        EmployeeR.of(employee_id,
                                "kstrijbos",
                                "gsbFsdpT",
                                "AAAAAA",
                                "Strijbos",
                                "Kevin",
                                true,
                                Role.ROLE_ADMIN)
                )));
    }
    
    @Test
    public void test_persist_employee_with_user() throws Exception {
        Employee employee = new Employee();
        int employee_id = employee.getEmployee_id() + 1;
        
        mockMvc.perform(post(EmployeeController.EMPLOYEE_BASE_URL + "/add")
                .with(user("user").roles("USER"))
                .content(asJson(EmployeeR.of(employee_id, "kstrijbos", "password", "AAAAAA", "Strijbos", "Kevin", true, Role.ROLE_USER)))
                .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().is(403));
    }
    
    @SuppressWarnings("unchecked")
    protected String asJson(Object o) throws IOException {
        MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
        this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
        return mockHttpOutputMessage.getBodyAsString();
    }
    
}