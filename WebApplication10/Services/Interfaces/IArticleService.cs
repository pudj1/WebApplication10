using WebApplication10.Models;

namespace WebApplication10.Services
{
    public interface IArticleService
    {
        public Task<Article> PostArticle(Article article);
        public Task<bool> DeleteArticle(Guid id);
        public Task<Article> UpdateArticle(Guid id, Article article);
        public Task<int> GetV1();
        public Task<string> GetV2();
        public Task<MemoryStream> GetV3();
    }
}
