using WebApplication10.Models.Base;

namespace WebApplication10.Models
{
    public class Comment : BaseModel
    {
        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public Guid ArticleId { get; set; }
        public DateTime Date { get; set; }
    }
}
