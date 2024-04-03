using Asp.Versioning;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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
        public async Task<ActionResult> GetV1()
        {
            var GetV1 = await ArticleService.GetV1();
            return Ok(GetV1);
        }

        [HttpGet(Name = "Article"), MapToApiVersion("2")]
        public async Task<ActionResult> GetV2()
        {
            var GetV2 = await ArticleService.GetV2();
            return Ok(GetV2);
        }

        [HttpGet(Name = "Article"), MapToApiVersion("3")]
        public async Task<ActionResult> GetV3()
        {
            var stream = await ArticleService.GetV3();
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "articles.xlsx");

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