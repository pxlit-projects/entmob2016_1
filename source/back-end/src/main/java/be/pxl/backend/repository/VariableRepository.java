package be.pxl.backend.repository;

import org.springframework.stereotype.Repository;
import be.pxl.backend.entity.Variable;
import org.springframework.data.jpa.repository.JpaRepository;

@Repository
public interface VariableRepository extends JpaRepository<Variable, Integer> {

}
