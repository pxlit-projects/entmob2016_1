package be.pxl.backend.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import be.pxl.backend.entity.Destination;
import org.springframework.stereotype.Repository;

@Repository
public interface DestinationRepository extends JpaRepository<Destination, Integer> {

}
