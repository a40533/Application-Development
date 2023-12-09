using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Repositories
{
    public interface IBorrowRepository : IRepository<Borrow>
    {
        Task<Borrow> FindByNameAsync(string name);
        Task<List<Borrow>> FindAllByNameStartedWithAsync(string name);
        Borrow GetById(int id);
        IQueryable<Borrow> GetAll();
    }

}