using System.Xml.Linq;
using WebApplication10.Models;

namespace WebApplication10.Services
{
    public class CommunityService : ICommunityService
    {
        private static List<Community> _list = new List<Community>();
        public CommunityService()
        {
            if (_list.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Community community = new Community
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Назва групи №{i + 1}",
                        Description = $"Опис групи №{i + 1}",
                        NumberOfParticipants = i*1234,
                    };
                    _list.Add(community);
                }
            }
        }
        public async Task DeleteCommunity(Guid id)
        {
            await Task.Run(() =>
            {
                Community? elem = _list.Find((elem) => elem.Id == id);
                bool result = false;
                if (elem != null)
                {
                    result = _list.Remove(elem);
                }
            });
        }

        public List<Community> GetAllCommunitys()
        {
            return _list;
        }

        public List<Community> PostCommunity(Community community)
        {
            community.Id = Guid.Empty;
            community.Id = Guid.NewGuid();
            _list.Add(community);
            return _list;
        }

        public List<Community> UpdateCommunity(Guid id, Community community)
        {
            if (id.ToString() != null) { 
                Community? elem = _list.Find((elem) => elem.Id == id);
                bool result = false;
                if (elem != null)
                {
                    result = _list.Remove(elem);
                }
                elem.Name = community.Name;
                elem.Description = community.Description;
                elem.NumberOfParticipants = community.NumberOfParticipants;
                _list.Add(elem);
                return _list;
            }
            return _list;
        }
    }
}
