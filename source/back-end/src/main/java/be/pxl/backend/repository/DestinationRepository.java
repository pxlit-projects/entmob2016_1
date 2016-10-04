package be.pxl.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import be.pxl.backend.entity.Destination;

public interface DestinationRepository extends JpaRepository<Destination, Integer> {

}
