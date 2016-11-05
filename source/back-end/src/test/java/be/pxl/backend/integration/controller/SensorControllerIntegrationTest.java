package be.pxl.backend.integration.controller;

import be.pxl.backend.controller.SensorController;
import be.pxl.backend.entity.Sensor;
import be.pxl.backend.representation.SensorR;
import be.pxl.backend.service.ISensorService;
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
import static be.pxl.backend.builder.SensorBuilder.*;
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
public class SensorControllerIntegrationTest {
    
    private MockMvc mockMvc;
    
    @Autowired
    private ISensorService service;
    
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
        List<Sensor> sensors = service.all();
        
        for(Sensor sensor : sensors) {
            service.hardDelete(sensor.getSensor_id());
        }
        
        mockMvc = MockMvcBuilders.webAppContextSetup(context)
                .apply(SecurityMockMvcConfigurers.springSecurity())
                .build();
    }
    
    @Test
    public void test_get_sensor_by_id() throws Exception {
        Sensor sensor = aSensor()
                .withSensorName("Sensor 1")
                .build();
        
        service.persist(sensor);
        
        int sensor_id = sensor.getSensor_id();
        
        mockMvc.perform(get(SensorController.SENSOR_BASE_URL + "/get/" + sensor_id)
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        SensorR.of(sensor_id,
                                "Sensor 1",
                                true)
                )));
    }
    
    @Test
    public void test_all_sensors () throws Exception {
        Sensor sensor = aSensor()
                .withSensorName("Sensor 1")
                .build();
        
        service.persist(sensor);
        
        int sensor_id = sensor.getSensor_id();
        
        mockMvc.perform(get(SensorController.SENSOR_BASE_URL + "/all/")
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        singletonList(SensorR.of(sensor_id,
                                "Sensor 1",
                                true))
                )));
    }
    
    @Test
    public void test_persist_sensor_with_admin() throws Exception {
        Sensor sensor = new Sensor();
        service.persist(sensor);
        int sensor_id = service.all().get(0).getSensor_id() + 1;
        
        mockMvc.perform(post(SensorController.SENSOR_BASE_URL + "/add")
                .with(user("admin").roles("ADMIN"))
                .content(asJson(SensorR.of(sensor_id, "Sensor 1", true)))
                .contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(status().isCreated());
        
        mockMvc.perform(get(SensorController.SENSOR_BASE_URL + "/get/" + sensor_id)
                .with(user("user").roles("ADMIN")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        SensorR.of(sensor_id,
                                "Sensor 1",
                                true)
                )));
    }
    
    @Test
    public void test_persist_sensor_with_user() throws Exception {
        Sensor sensor = new Sensor();
        int sensor_id = sensor.getSensor_id() + 1;
    
        mockMvc.perform(post(SensorController.SENSOR_BASE_URL + "/add")
                .with(user("user").roles("USER"))
                .content(asJson(SensorR.of(sensor_id, "Sensor 1", true)))
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