package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import be.pxl.backend.entity.Login;
import be.pxl.backend.service.LoginService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(LoginController.LOGIN_BASE_URL)
public class LoginController {
	public static final String LOGIN_BASE_URL = "/logins";
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
	
	@RequestMapping(value = "/add", method=RequestMethod.POST)
	@ResponseStatus (value = HttpStatus.CREATED)
	public void addLogin(@RequestBody Login login) {
		service.persist(login);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteLogin(@PathVariable("id") int id) {
		service.delete(id);
	}

}
