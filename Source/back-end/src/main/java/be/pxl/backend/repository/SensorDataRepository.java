package be.pxl.backend.repository;

import be.pxl.backend.entity.SensorData;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Created by Bram on 7/10/2016.
 */
public interface SensorDataRepository extends JpaRepository<SensorData, Integer> {
}
