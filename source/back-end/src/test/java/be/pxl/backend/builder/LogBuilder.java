package be.pxl.backend.builder;

import be.pxl.backend.entity.Log;

public class LogBuilder {
    
    private String message;
    
    public Log build() { return new Log(message); }
    
    public static LogBuilder aLog() {
        return new LogBuilder();
    }
    
    public LogBuilder withMessage(String message) {
        this.message = message;
        return this;
    }
    public String getMessage() { return message; }
    
}
