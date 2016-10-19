package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import be.pxl.backend.entity.Login;
import be.pxl.backend.repository.LoginRepository;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class LoginService implements ILoginService {

	@Autowired
	private LoginRepository repo;
	
	public Login find(int id) {
		return repo.findOne(id);
	}
	
	public List<Login> all() {
		return repo.findAll();
	}
	
	public void persist(Login login) {
		repo.save(login);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}

}
