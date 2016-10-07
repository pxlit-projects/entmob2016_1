package be.pxl.backend.controller;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.entity.Comment;
import be.pxl.backend.service.CargoService;
import be.pxl.backend.service.CommentService;
import be.pxl.backend.service.*;
@RestController
@RequestMapping(CommentController.COMMENTS_BASE_URL)
public class CommentController {

	public static final String COMMENTS_BASE_URL = "/comments";
	@Autowired
	private ICommentService service;
	
	@RequestMapping(value = "/get/{id}", method = RequestMethod.GET, produces="application/json")
	public Comment getCommentById(@PathVariable("id") int id) {
		return service.find(id);
	}
	
	@RequestMapping(value = "/all", method = RequestMethod.GET, produces="application/json")
	public List<Comment> getAllComments() {
		return service.all();
	}
	
	@RequestMapping(value = "/add/{comment}", method=RequestMethod.POST)
	public void addComment(@RequestBody Comment comment) {
		service.persist(comment);
	}
	
	@RequestMapping(value = "/delete/{id}", method=RequestMethod.DELETE)
	public void deleteComment(@PathVariable("id") int id) {
		service.delete(id);
	}
	
	@RequestMapping(value = "/update/{id}", method=RequestMethod.PUT)
	public void updateComment(@PathVariable("id") int id, @RequestBody Comment comment) {
		service.update(id, comment);
	}
}
