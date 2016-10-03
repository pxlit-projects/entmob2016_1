package be.pxl.backend.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Component;
import be.pxl.backend.entity.*;

@Component
public interface ProductRepository extends CrudRepository<Product, Integer> {

}
