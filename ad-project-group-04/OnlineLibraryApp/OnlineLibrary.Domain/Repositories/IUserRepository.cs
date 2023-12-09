using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByNameAsync(string name);
        Task<List<User>> FindAllByNameStartedWithAsync(string name);
        IQueryable<User> GetAll();
        User GetById(int id);
    }
}