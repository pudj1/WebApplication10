using WebApplication10.Models;

namespace WebApplication10.Services
{
    public interface ICommunityService
    {
        public List<Community> GetAllCommunitys();
        public List<Community> PostCommunity(Community community);
        public Task DeleteCommunity(Guid id);
        public List<Community> UpdateCommunity(Guid id, Community community);
    }
}
