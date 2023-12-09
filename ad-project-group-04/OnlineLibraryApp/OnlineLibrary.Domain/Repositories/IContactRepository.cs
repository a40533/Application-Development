using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<Contact> FindByNameAsync(string name);
        Task<List<Contact>> FindAllByNameStartedWithAsync(string name);
        IQueryable<Contact> GetAll();
        Contact GetById(int id);
    }

}