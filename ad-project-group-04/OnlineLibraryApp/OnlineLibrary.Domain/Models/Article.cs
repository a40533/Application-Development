using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Models
{
    public class Article : Entity
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string DatePublished { get; set; }
    }
}