package be.pxl.backend.representation;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;

public class SensorR {
    
    private int sensor_id;
    private String sensor_name;
    private boolean status;
    
    public static SensorR of(int sensor_id, String sensor_name, boolean status) { return new SensorR(sensor_id, sensor_name, status); }
    
    @JsonCreator
    private SensorR(@JsonProperty("sensor_id")int sensor_id, @JsonProperty("sensor_name")String sensor_name, @JsonProperty("status")boolean status) {
        this.sensor_id = sensor_id;
        this.sensor_name = sensor_name;
        this.status = status;
    }
    
    public int getSensor_id () {
        return sensor_id;
    }
    public String getSensor_name () {
        return sensor_name;
    }
    public boolean isStatus () {
        return status;
    }
    
    public String toString() {
        return "SensorR{" +
                "sensor_id='" + sensor_id + '\'' +
                ", sensor_name='" + sensor_name + '\'' +
                ", status='" + status + '\'' +
                '}';
    }
}
