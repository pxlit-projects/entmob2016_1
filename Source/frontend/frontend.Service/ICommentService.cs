using frontend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Service
{
    public interface ICommentService
    {
        List<Comment> All();
        Comment Find(int id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int id);
    }
}
