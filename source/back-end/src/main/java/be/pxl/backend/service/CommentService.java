package be.pxl.backend.service;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import be.pxl.backend.entity.Cargo;
import be.pxl.backend.entity.Comment;
import be.pxl.backend.repository.CommentRepository;

@Component
public class CommentService {

	@Autowired
	private CommentRepository repo;
	
	public Comment find(int id) {
		return repo.findOne(id);
	}
	
	public List<Comment> all() {
		return repo.findAll();
	}
	
	public void persist(Comment comment) {
		repo.save(comment);
	}
	
	public void delete(int id) {
		repo.delete(id);
	}
	
	public void update(int id, Comment comment) {
		this.delete(id);
		this.persist(comment);
	}
	
}
