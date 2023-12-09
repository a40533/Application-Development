using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> FindByNameAsync(string name);
        Task<List<Article>> FindAllByNameStartedWithAsync(string name);
        IQueryable<Article> GetAll();
        Article GetById(int id);
    }

}