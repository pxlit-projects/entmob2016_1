package be.pxl.backend.service;

import be.pxl.backend.entity.Log;
import be.pxl.backend.repository.LogRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import java.util.List;

@Service
@Transactional
public class LogService implements ILogService {
    
    @Autowired
    private LogRepository repo;
    
    public void persist (Log log) {
        repo.save(log);
    }
    public List<Log> all() { return repo.findAll(); }
    public void delete(int id) { repo.delete(id); }
    
}
