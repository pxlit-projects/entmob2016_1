package be.pxl.backend.entity;

import javax.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "Logs")
public class Log {
    
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int id;
    private LocalDateTime localDateTime = LocalDateTime.now();
    private String message;
    
    public int getId () {
        return id;
    }
    
    public LocalDateTime getLocalDateTime () {
        return localDateTime;
    }
    
    public String getMessage () {
        return message;
    }
    
    public void setMessage (String message) {
        this.message = message;
    }
}
