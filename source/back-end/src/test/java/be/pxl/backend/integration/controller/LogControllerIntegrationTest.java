package be.pxl.backend.integration.controller;

import be.pxl.backend.controller.LogController;
import be.pxl.backend.entity.Log;
import be.pxl.backend.representation.LogR;
import be.pxl.backend.service.ILogService;
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
import java.sql.Timestamp;
import java.util.Date;
import java.util.List;
import static be.pxl.backend.builder.LogBuilder.*;
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
public class LogControllerIntegrationTest {
    
    private MockMvc mockMvc;
    
    @Autowired
    private ILogService service;
    
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
        List<Log> logs = service.all();
        
        for(Log log : logs) {
            service.delete(log.getId());
        }
        
        mockMvc = MockMvcBuilders.webAppContextSetup(context)
                .apply(SecurityMockMvcConfigurers.springSecurity())
                .build();
    }
    
    @Test
    public void test_all_logs () throws Exception {
        Log log = aLog()
                .withMessage("Test log.")
                .build();

        service.persist(log);
        
        int log_id = log.getId();
        
        mockMvc.perform(get(LogController.LOG_BASE_URL + "/all/")
                .with(user("user").roles("USER")))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON_UTF8))
                .andExpect(content().json(asJson(
                        singletonList(LogR.of(log_id,
                                "Test log.",
                                log.getTime()))
                )));
    }
    
    @SuppressWarnings("unchecked")
    protected String asJson(Object o) throws IOException {
        MockHttpOutputMessage mockHttpOutputMessage = new MockHttpOutputMessage();
        this.mappingJackson2HttpMessageConverter.write(o, MediaType.APPLICATION_JSON, mockHttpOutputMessage);
        return mockHttpOutputMessage.getBodyAsString();
    }
    
}