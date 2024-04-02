using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WebApplication10.Models;
using WebApplication10.Services;

namespace WebApplication10.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommentController : ControllerBase
    {
        private ICommentService CommentService { get; set; }

        public CommentController(ICommentService articleService)
        {
            CommentService = articleService;
        }

        [HttpGet(Name = "Comment")]
        public JsonResult Get()
        {
            return new JsonResult(CommentService.GetAllComments());
        }

        [HttpPost(Name = "Comment")]
        public JsonResult Post(Comment article)
        {
            return new JsonResult(CommentService.PostComment(article));
        }

        [HttpPut(Name = "Comment")]
        public JsonResult Put(Guid id, Comment article)
        {
            return new JsonResult(CommentService.UpdateComment(id, article));
        }

        [HttpDelete(Name = "Comment")]
        public JsonResult Delete(Guid id)
        {
            return new JsonResult(CommentService.DeleteComment(id));
        }
    }
}