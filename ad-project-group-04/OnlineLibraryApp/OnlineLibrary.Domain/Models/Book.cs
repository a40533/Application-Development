using System.Collections.Generic;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishedDate { get; set; }
        public int Quantity { get; set; }
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();
        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}