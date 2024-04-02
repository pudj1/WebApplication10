using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Models;

namespace WebApplication10.Services
{
    public class ArticleService : IArticleService
    {
        private static List<Article> _list = new List<Article>();
        public ArticleService() {
            if (_list.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Article article = new Article
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Стаття №{i + 1}",
                        Content = $"Вміст статті №{i + 1}",
                        Date = DateTime.Now.AddDays(-i)
                    };
                    _list.Add(article);
                }
            }
        }
        public async Task<bool> DeleteArticle(Guid id)
        {
            Article? elem = _list.Find((elem) => elem.Id == id);
            bool result = false;
            if (elem != null)
            {
                result = _list.Remove(elem);
            }
            return result;
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            return _list;
        }

        public async Task<Article> PostArticle(Article article)
        {
            article.Id = Guid.Empty;
            article.Id = Guid.NewGuid();
            _list.Add(article);
            return article;
        }

        public async Task<Article> UpdateArticle(Guid id, Article article)
        {
            Article? elem = _list.Find((elem) => elem.Id == id);
            bool result = false;
            if (elem != null)
            {
                result = _list.Remove(elem);
            }
            elem.Content = article.Content;
            elem.Date = article.Date;
            elem.Name = article.Name;
            _list.Add(elem);
            return elem;
        }
    }
}
