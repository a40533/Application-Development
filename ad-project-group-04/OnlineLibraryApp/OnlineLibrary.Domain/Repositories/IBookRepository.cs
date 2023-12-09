using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> FindByNameAsync(string name);
        Task<List<Book>> FindAllByNameStartedWithAsync(string name);
        IQueryable<Book> GetAll();
        Book GetById(int id);
    }

}