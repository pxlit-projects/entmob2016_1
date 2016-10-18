using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Domain;
using frontend.Repository;

namespace frontend.Service
{
    public class CommentService : ICommentService
    {
        private CommentRepository commentRepository;

        public CommentService()
        {
            commentRepository = new CommentRepository();
        }

        public void Add(Comment comment)
        {
            commentRepository.AddComment(comment);
        }

        public List<Comment> All()
        {
            return commentRepository.GetAllComments().Result.ToList();
        }

        public void Delete(int id)
        {
            commentRepository.DeleteComment(id);
        }

        public Comment Find(int id)
        {
            return commentRepository.GetCommentById(id).Result;
        }

        public void Update(Comment comment)
        {
            commentRepository.UpdateComment(comment);
        }
    }
}
