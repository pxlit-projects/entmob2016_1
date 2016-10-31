package be.pxl.backend.repository;

import be.pxl.backend.entity.Cargo;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;
import java.util.Arrays;
import java.util.List;
import static be.pxl.backend.builder.CargoBuilder.*;
import static org.assertj.core.api.Assertions.assertThat;

@RunWith(SpringRunner.class)
@SpringBootTest
public class CargoRepositoryTest {
    
    @Autowired
    private CargoRepository repo;
    
    @Before
    public void deleteAll() {
        repo.deleteAll();
    }
    
    @Test
    public void test_get_cargo_by_sensor() {
        Cargo c1 = aCargo()
                .withSensorId(1)
                .withWeight(500)
                .build();
        Cargo c2 = aCargo()
                .withSensorId(2)
                .withWeight(100)
                .build();
        Cargo c3 = aCargo()
                .withSensorId(3)
                .withWeight(50)
                .build();
        
        repo.save(Arrays.asList(c1, c2, c3));
        
        List<Cargo> cargos = repo.findBySensor(2);
        
        assertThat(cargos).extracting(Cargo::getSensor_id).containsOnly(2);
    }
    
}