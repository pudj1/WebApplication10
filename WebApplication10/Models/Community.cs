using WebApplication10.Models.Base;

namespace WebApplication10.Models
{
    public class Community : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Int64 NumberOfParticipants { get; set; }
    }
}
