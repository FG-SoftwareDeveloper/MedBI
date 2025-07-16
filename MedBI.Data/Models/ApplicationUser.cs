using Microsoft.AspNetCore.Identity;


namespace MedBI.Data.Models
{
    public class ApplicationUser : IdentityUser
    {


        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();

        public ICollection<ErrorLogs> ErrorLogs { get; set; }
        public ICollection<SystemLogs> SystemLogs { get; set; }
    }
}
