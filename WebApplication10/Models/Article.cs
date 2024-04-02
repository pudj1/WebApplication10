using WebApplication10.Models.Base;

namespace WebApplication10.Models
{
    public class Article : BaseModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
