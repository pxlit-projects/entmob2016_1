package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import javax.persistence.*;
import java.sql.Timestamp;
import java.util.Date;

@Entity
@Table(name = "sensor_data")
public class SensorData {
    
    @Id
    @GeneratedValue (strategy= GenerationType.AUTO)
    private int sensor_data_id;
    private float temperature;
    private float humidity;
    private float magnetism;
    private float pressure;
    private float gyroscope;
    private float light;
    private float acceleration;
    private Timestamp time = new Timestamp(new Date().getTime());
    @ManyToOne
    @JsonBackReference(value = "sensor_data")
    private Sensor sensor;
    
    public int getSensor_data_id () {
        return sensor_data_id;
    }
    public float getTemperature () {
        return temperature;
    }
    public float getHumidity () {
        return humidity;
    }
    public float getMagnetism () {
        return magnetism;
    }
    public float getPressure () {
        return pressure;
    }
    public float getGyroscope () {
        return gyroscope;
    }
    public float getLight () {
        return light;
    }
    public float getAcceleration () {
        return acceleration;
    }

}
