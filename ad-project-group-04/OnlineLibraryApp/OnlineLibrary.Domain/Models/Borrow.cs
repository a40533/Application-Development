using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Models
{
    public class Borrow : Entity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public string BorrowDate { get; set; }
        public string ReturnDate { get; set; }
    }
}