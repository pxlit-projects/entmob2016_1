package be.pxl.backend.builder;

import be.pxl.backend.entity.Sensor;

public class SensorBuilder {
    
    private String sensorName;
    
    public static SensorBuilder aSensor() {
        return new SensorBuilder();
    }
    
    public Sensor build() {
        return new Sensor(sensorName);
    }
    
    public SensorBuilder withSensorName(String sensorName) {
        this.sensorName = sensorName;
        return this;
    }
    
}
