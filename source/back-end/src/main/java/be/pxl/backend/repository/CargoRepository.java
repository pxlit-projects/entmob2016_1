package be.pxl.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import be.pxl.backend.entity.*;
import java.util.List;

@Repository
public interface CargoRepository extends JpaRepository<Cargo, Integer> {
    @Query ("from Cargo c where c.sensor_id = :sensor_id")
    List<Cargo> findBySensor(@Param ("sensor_id")int sensor_id);
}
