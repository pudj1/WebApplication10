using WebApplication10.Models;

namespace WebApplication10.Services
{
    public class CommentService : ICommentService
    {
        private static List<Comment> _list = new List<Comment>();
        public CommentService()
        {
            if (_list.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Comment comment = new Comment
                    {
                        Id = Guid.NewGuid(),
                        AuthorId = Guid.NewGuid(),
                        ArticleId = Guid.NewGuid(),
                        Content = $"Вміст коментарію №{i + 1}",
                        Date = DateTime.Now.AddDays(-i)
                    };
                    _list.Add(comment);
                }
            }
        }
        public async Task DeleteComment(Guid id)
        {
            await Task.Run(() =>
            {
                Comment? elem = _list.Find((elem) => elem.Id == id);
                bool result = false;
                if (elem != null)
                {
                    result = _list.Remove(elem);
                }
            });
        }

        public List<Comment> GetAllComments()
        {
            return _list;
        }

        public List<Comment> PostComment(Comment comment)
        {
            comment.Id = Guid.Empty;
            comment.Id = Guid.NewGuid();
            _list.Add(comment);
            return _list;
        }

        public List<Comment> UpdateComment(Guid id, Comment comment)
        {
            Comment? elem = _list.Find((elem) => elem.Id == id);
            bool result = false;
            if (elem != null)
            {
                result = _list.Remove(elem);
            }
            elem.ArticleId = comment.ArticleId;
            elem.AuthorId = comment.AuthorId;
            elem.Date = comment.Date;
            elem.Content = comment.Content;
            _list.Add(elem);
            return _list;
        }
    }
}
