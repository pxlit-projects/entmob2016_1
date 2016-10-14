package be.pxl.backend.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import be.pxl.backend.entity.*;

@Repository
public interface EmployeeRepository extends JpaRepository<Employee, Integer> {
    @Query("from Employee e where e.username = :username")
    Employee getEmployeeByUsername(@Param("username")String username);
}
