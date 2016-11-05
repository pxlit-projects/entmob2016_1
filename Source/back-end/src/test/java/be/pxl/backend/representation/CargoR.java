package be.pxl.backend.representation;

import com.fasterxml.jackson.annotation.JsonCreator;
import com.fasterxml.jackson.annotation.JsonProperty;

public class CargoR {
    
    private int cargo_id;
    private int sensor_id;
    private float weight;
    
    public static CargoR of(int cargo_id, int sensor_id, float weight) {
        return new CargoR(cargo_id, sensor_id, weight);
    }
    
    @JsonCreator
    private CargoR(@JsonProperty("cargo_id")int cargo_id, @JsonProperty("sensor_id")int sensor_id, @JsonProperty("weight")float weight) {
        this.cargo_id = cargo_id;
        this.sensor_id = sensor_id;
        this.weight = weight;
    }
    
    public int getCargo_id() { return cargo_id; }
    public int getSensor_id() { return sensor_id; }
    public float getWeight() { return weight; }
    
    @Override
    public String toString() {
        return "CargoR{" +
                "cargo_id='" + cargo_id + '\'' +
                ", sensor_id='" + sensor_id + '\'' +
                ", weight='" + weight + '\'' +
                '}';
    }
}
