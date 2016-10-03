package be.pxl.backend.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import be.pxl.backend.entity.*;

@Repository
public interface ProductRepository extends CrudRepository<Product, Integer> {

}
