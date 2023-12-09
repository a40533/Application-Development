using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> FindByNameAsync(string name);
        Task<List<Category>> FindAllByNameStartedWithAsync(string name);
        IQueryable<Category> GetAll();
        Category GetById(int id);
    }

}