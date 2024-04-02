using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WebApplication10.Models;
using WebApplication10.Services;

namespace WebApplication10.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommunityController : ControllerBase
    {
        private ICommunityService CommunityService { get; set; }

        public CommunityController(ICommunityService articleService)
        {
            CommunityService = articleService;
        }

        [HttpGet(Name = "Community")]
        public JsonResult Get()
        {
            return new JsonResult(CommunityService.GetAllCommunitys());
        }

        [HttpPost(Name = "Community")]
        public JsonResult Post(Community article)
        {
            return new JsonResult(CommunityService.PostCommunity(article));
        }

        [HttpPut(Name = "Community")]
        public JsonResult Put(Guid id, Community article)
        {
            return new JsonResult(CommunityService.UpdateCommunity(id, article));
        }

        [HttpDelete(Name = "Community")]
        public JsonResult Delete(Guid id)
        {
            return new JsonResult(CommunityService.DeleteCommunity(id));
        }
    }
}