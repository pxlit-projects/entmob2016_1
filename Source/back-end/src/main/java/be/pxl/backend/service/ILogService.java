package be.pxl.backend.service;

import be.pxl.backend.entity.Log;

public interface ILogService {
    
    public void persist(Log log);
    
}
