package be.pxl.backend.integration.controller;

import be.pxl.backend.controller.CargoController;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.representation.CargoR;
import be.pxl.backend.service.ICargoService;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.http.converter.HttpMessageConverter;
import org.springframework.http.converter.json.MappingJackson2HttpMessageConverter;
import org.springframework.mock.http.MockHttpOutputMessage;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;
import org.springframework.web.context.WebApplicationContext;
import java.io.IOException;
import java.util.List;
import static be.pxl.backend.builder.CargoBuilder.*;
import static java.util.Arrays.asList;
import static java.util.Collections.singletonList;
import static org.assertj.core.api.Assertions.assertThat;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.user;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import org.springframework.security.test.web.servlet.setup.SecurityMockMvcConfigurers;

@RunWith (SpringRunner.class)
@SpringBootTest
public class CargoControllerIntegrationTest {
    
    private MockMvc mockMvc;
    
    @Autowired
    private ICargoService service;
    
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
        List<Cargo> cargos = service.all();
        
        for(Cargo cargo : cargos) {
            service.delete(cargo.getCargo_id());
        }
        
        mockMvc = MockMvcBuilders.webAppContextSetup(context)
                .apply(SecurityMockMvcConfigurers.springSecurity())
                .build();
    }
    
    @Test
    public void test_get_cargo_by_id() throws Exception {
        Cargo cargo = aCargo()
                .withSensorId(1)
                .withWeight(500)
                .build();
        
        service.persist(cargo);
        
        int cargo_id = cargo.getCargo_id();
        
        mockMvc.perform(get(CargoController.CARGO_BASE_URL + "/get/" + cargo_id)
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        CargoR.of(cargo_id,
                                1,
                                500)
                )));
    }
    
    @Test
    public void test_get_all_cargos() throws Exception {
        Cargo cargo = aCargo()
                .withSensorId(1)
                .withWeight(500)
                .build();
        
        service.persist(cargo);
        
        int cargo_id = cargo.getCargo_id();

        mockMvc.perform(get(CargoController.CARGO_BASE_URL + "/all")
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        singletonList(CargoR.of(cargo_id,
                                1,
                                500))
                )));
    }
    
    @Test
    public void test_persist_cargo_with_admin() throws Exception {
        Cargo cargo = new Cargo();
        service.persist(cargo);
        int cargo_id = service.all().get(0).getCargo_id() + 1;
    
        mockMvc.perform(post(CargoController.CARGO_BASE_URL + "/add")
                .with(user("admin").roles("ADMIN"))
                .content(asJson(CargoR.of(cargo_id, 1, 500)))
                .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().isCreated());
        
        System.out.println("ID: " + cargo_id);
        mockMvc.perform(get(CargoController.CARGO_BASE_URL + "/get/" + cargo_id)
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        CargoR.of(cargo_id,
                                1,
                                500)
                )));
    }
    
    @Test
    public void test_persist_cargo_with_user() throws Exception {
        Cargo cargo = new Cargo();
        int cargo_id = cargo.getCargo_id() + 1;
        
        mockMvc.perform(post(CargoController.CARGO_BASE_URL + "/add")
                .with(user("user").roles("USER"))
                .content(asJson(CargoR.of(cargo_id, 1, 500)))
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