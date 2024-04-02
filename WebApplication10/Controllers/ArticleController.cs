using Asp.Versioning;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication10.Models;
using WebApplication10.Services;

namespace WebApplication10.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiVersion("3")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleService ArticleService { get; set; }

        public ArticleController(IArticleService articleService)
        {
            ArticleService = articleService;
        }

        [HttpGet(Name ="Article"), MapToApiVersion("1")]
        public IActionResult GetV1()
        {
            return Ok(123);
        }

        [HttpGet(Name = "Article"), MapToApiVersion("2")]
        public IActionResult GetV2()
        {
            return Ok("123");
        }

        [HttpGet(Name = "Article"), MapToApiVersion("3")]
        public async Task<ActionResult> GetV3()
        {
            var articles = await ArticleService.GetAllArticles();
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "articles.xlsx");
                }
            }
        }

        [HttpPost(Name = "Article")]
        public async Task<ActionResult<Article>> Post(Article article)
        {
            var createdArticle = await ArticleService.PostArticle(article);
            return Ok(createdArticle);
        }

        [HttpPut(Name = "Article")]
        public async Task<ActionResult<Article>> Put(Guid id, Article article)
        {
            var updatedArticle = await ArticleService.UpdateArticle(id, article);
            return Ok(updatedArticle);
        }

        [HttpDelete(Name = "Article")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await ArticleService.DeleteArticle(id);
            return Ok(result);
        }
    }
}