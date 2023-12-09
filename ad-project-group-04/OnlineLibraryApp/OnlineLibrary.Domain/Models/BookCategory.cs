using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Models
{
    public class BookCategory : Entity
    {
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}