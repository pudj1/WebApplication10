using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Models;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;

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

        public async Task<int> GetV1()
        {
            return 123;
        }

        public async Task<string> GetV2()
        {
            return "123";
        }
        public async Task<MemoryStream> GetV3()
        {
            var articles = _list;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Articles");
                worksheet.Cell(1, 1).Value = "Name";
                worksheet.Cell(1, 2).Value = "Content";
                worksheet.Cell(1, 3).Value = "Date";

                int row = 2;
                foreach (var article in articles)
                {
                    worksheet.Cell(row, 1).Value = article.Name;
                    worksheet.Cell(row, 2).Value = article.Content;
                    worksheet.Cell(row, 3).Value = article.Date.ToString();
                    row++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
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
