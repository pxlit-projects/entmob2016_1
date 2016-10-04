package be.pxl.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import be.pxl.backend.entity.City;

public interface CityRepository extends JpaRepository<City, String> {

}
