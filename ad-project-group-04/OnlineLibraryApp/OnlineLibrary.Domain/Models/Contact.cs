using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Models
{
    public class Contact : Entity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
    }
}