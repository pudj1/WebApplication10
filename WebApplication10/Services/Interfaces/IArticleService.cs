using WebApplication10.Models;

namespace WebApplication10.Services
{
    public interface IArticleService
    {
        public Task<IEnumerable<Article>> GetAllArticles();
        public Task<Article> PostArticle(Article article);
        public Task<bool> DeleteArticle(Guid id);
        public Task<Article> UpdateArticle(Guid id, Article article);
    }
}
