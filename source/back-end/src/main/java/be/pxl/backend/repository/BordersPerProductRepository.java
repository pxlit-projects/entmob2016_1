package be.pxl.backend.repository;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import be.pxl.backend.entity.*;

@Repository
public interface BordersPerProductRepository extends JpaRepository<BordersPerProduct, BordersPerProductPK>  {

}
