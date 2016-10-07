package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Login;
import be.pxl.backend.service.LoginService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping("/logins")
public class LoginController {
	
	@Autowired
	private ILoginService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Login getLoginById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Login> getAllLogins() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{login}", method=RequestMethod.POST)
	public void addLogin(@RequestBody Login login) {
		service.persist(login);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteLogin(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateLogin(@PathVariable("id") int id, @RequestBody Login login) {
		service.update(id, login);
	}
}
