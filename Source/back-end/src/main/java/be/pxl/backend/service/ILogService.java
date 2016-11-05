package be.pxl.backend.service;

import be.pxl.backend.entity.Log;
import java.util.List;

public interface ILogService {
    
    public void persist(Log log);
    public List<Log> all();
    public void delete(int id);
    
}
