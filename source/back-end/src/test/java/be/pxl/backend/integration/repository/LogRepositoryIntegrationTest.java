package be.pxl.backend.integration.repository;

import be.pxl.backend.entity.Log;
import be.pxl.backend.repository.LogRepository;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;
import java.util.Arrays;
import java.util.List;
import static be.pxl.backend.builder.LogBuilder.*;
import static org.assertj.core.api.Assertions.assertThat;

@RunWith(SpringRunner.class)
@SpringBootTest
public class LogRepositoryIntegrationTest {
    
    @Autowired
    private LogRepository repo;
    
    @Before
    public void deleteAll() {
        repo.deleteAll();;
    }
    
    @Test
    public void test_persist_log() {
        Log log = aLog().withMessage("This is a test message.").build();
        
        repo.save(log);
        
        assertThat(repo.findAll().get(0).getMessage().equals("This is a test message."));
    }
    
    @Test
    public void test_delete_log() {
        Log l1 = aLog().withMessage("Test message #1").build();
        Log l2 = aLog().withMessage("Test message #2").build();
        
        repo.save(Arrays.asList(l1,l2));
        
        List<Log> logs = repo.findAll();
        int log_id = logs.get(logs.size()-1).getId();
        
        repo.delete(log_id);
        
        assertThat(repo.findAll().get(0).getMessage().equals("Test message #1"));
    }
    
}
