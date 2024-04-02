using WebApplication10.Models;

namespace WebApplication10.Services
{
    public interface ICommentService
    {
        public List<Comment> GetAllComments();
        public List<Comment> PostComment(Comment comment);
        public Task DeleteComment(Guid id);
        public List<Comment> UpdateComment(Guid id, Comment comment);
    }
}
