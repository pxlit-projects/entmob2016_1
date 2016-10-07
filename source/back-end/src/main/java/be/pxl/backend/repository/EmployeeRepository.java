package be.pxl.backend.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import be.pxl.backend.entity.*;

@Repository
public interface EmployeeRepository extends JpaRepository<Employee, Integer> {

}