using System.Collections.Generic;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
        public List<Borrow> Borrows { get; set; } = new List<Borrow>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}