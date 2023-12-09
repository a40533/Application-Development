using System.Collections.Generic;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}