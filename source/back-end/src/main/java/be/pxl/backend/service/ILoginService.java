package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Login;

public interface ILoginService {

	public Login find(int id);
	
	public List<Login> all();
	
	public void persist(Login login);
	
	public void delete(int id);
	
}
