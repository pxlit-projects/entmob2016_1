package be.pxl.backend.service;

import java.util.List;
import be.pxl.backend.entity.Comment;

public interface ICommentService {

	public Comment find(int id);
	
	public List<Comment> all();
	
	public void persist(Comment comment);
	
	public void delete(int id);
	
	public void update(int id, Comment comment);
	
}
