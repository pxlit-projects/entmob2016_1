package be.pxl.backend.representation;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;
import org.mockito.internal.verification.Times;

import java.sql.Timestamp;

public class LogR {
    
    private int log_id;
    private String message;
    private Timestamp time;
    
    public static LogR of(int log_id, String message, Timestamp time) { return new LogR(log_id, message, time); }
    
    @JsonCreator
    private LogR(@JsonProperty("log_id")int log_id, @JsonProperty("message")String message, @JsonProperty("time")Timestamp time) {
        this.log_id = log_id;
        this.message = message;
        this.time = time;
    }
    
    public int getId () {
        return log_id;
    }
    public String getMessage() {
        return message;
    }
    public Timestamp getTime() { return time; }
    
    public String toString() {
        return "LogR{" +
                "time='" + time + '\'' +
                ", message='" + message + '\'' +
                ", id='" + log_id + '\'' +
                '}';
    }
}
