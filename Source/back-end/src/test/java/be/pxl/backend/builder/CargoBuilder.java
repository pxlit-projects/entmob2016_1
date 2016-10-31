package be.pxl.backend.builder;

import be.pxl.backend.entity.Cargo;

public class CargoBuilder {
    
    private int sensor_id;
    private float weight;
    
    public static CargoBuilder aCargo() {
        return new CargoBuilder();
    }
    
    public Cargo build() {
        return new Cargo(sensor_id, weight);
    }
    
    public CargoBuilder withSensorId(int id) {
        this.sensor_id = id;
        return this;
    }
    
    public CargoBuilder withWeight(float weight) {
        this.weight = weight;
        return this;
    }
    
}
