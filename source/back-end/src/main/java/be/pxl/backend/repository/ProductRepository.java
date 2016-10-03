package be.pxl.backend.repository;

import org.springframework.data.repository.CrudRepository;
import be.pxl.backend.entity.*;

public interface ProductRepository extends CrudRepository<Product, Integer> {

}
