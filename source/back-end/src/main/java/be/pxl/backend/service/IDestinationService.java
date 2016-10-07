package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Destination;
import org.springframework.stereotype.Service;

public interface IDestinationService {

    public Destination find(int id);

    public List<Destination> all();

    public void persist(Destination destination);

    public void delete(int id);

    public void update(int id, Destination destination);

}
