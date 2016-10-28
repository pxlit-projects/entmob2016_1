package be.pxl.backend.entity;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIgnore;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.*;

@Entity
@Table(name="Sensor_data")
public class SensorData {

    @Id
    @GeneratedValue(strategy=GenerationType.AUTO)
    private int sensor_data_id;
    private Date time;
    private double temperature;
    private double humidity;
    private double baroMeter;
    private double acceleroMeter;
    private double magnetMeter;
    private double gyroscoop;
    private double lightsensor;
    @ManyToOne
    @JsonBackReference
    private Sensor sensor;

    public int getSensor_data_id() {
        return sensor_data_id;
    }

    public void setSensor_data_id(int sensor_data_id) {
        this.sensor_data_id = sensor_data_id;
    }

    public Date getTime() {
        return time;
    }

    public void setTime(Date time) {
        this.time = time;
    }

    public double getTemperature() {
        return temperature;
    }

    public void setTemperature(double temperature) {
        this.temperature = temperature;
    }

    public double getHumidity() {
        return humidity;
    }

    public void setHumidity(double humidity) {
        this.humidity = humidity;
    }

    public double getBaroMeter() {
        return baroMeter;
    }

    public void setBaroMeter(double baroMeter) {
        this.baroMeter = baroMeter;
    }

    public double getAcceleroMeter() {
        return acceleroMeter;
    }

    public void setAcceleroMeter(double acceleroMeter) {
        this.acceleroMeter = acceleroMeter;
    }

    public double getMagnetMeter() {
        return magnetMeter;
    }

    public void setMagnetMeter(double magnetMeter) {
        this.magnetMeter = magnetMeter;
    }

    public double getGyroscoop() {
        return gyroscoop;
    }

    public void setGyroscoop(double gyroscoop) {
        this.gyroscoop = gyroscoop;
    }

    public double getLightsensor() {
        return lightsensor;
    }

    public void setLightsensor(double lightsensor) {
        this.lightsensor = lightsensor;
    }
}
