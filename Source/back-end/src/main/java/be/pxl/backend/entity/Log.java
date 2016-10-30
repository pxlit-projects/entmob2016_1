package be.pxl.backend.entity;

import javax.persistence.*;
import java.sql.Timestamp;
import java.util.Date;

@Entity
@Table(name = "logs")
public class Log {
    
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int log_id;
    private Timestamp time = new Timestamp(new Date().getTime());
    @Column(length = 2056)
    private String message;
    
    public int getId () {
        return log_id;
    }
    public Timestamp getTime () {
        return time;
    }
    public String getMessage () {
        return message;
    }
    
    public void setMessage (String message) {
        this.message = message;
    }
    
}
