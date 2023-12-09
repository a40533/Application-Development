using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.Repositories;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(OnlineLibraryListDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Article>> FindAllByNameStartedWithAsync(string name)
        {
            return _dbContext.Articles.Where(c => c.Title.StartsWith(name)).OrderBy(x => x.Title).ToListAsync();
        }

        public Task<Article> FindByNameAsync(string name)
        {
            return _dbContext.Articles.SingleOrDefaultAsync(x => x.Title == name);
        }

        public IQueryable<Article> GetAll()
        {
            return _dbContext.Set<Article>().AsQueryable();
        }

        public Article GetById(int id)
        {
            return _dbContext.Set<Article>().Find(id);
        }

        public void Create(Article entity)
        {
            _dbContext.Set<Article>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Article entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Article entity)
        {
            _dbContext.Set<Article>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public override async Task<Article> FindOrCreateAsync(Article e)
        {
            var f = await _dbContext.Articles
                .SingleOrDefaultAsync(x => x.Title == e.Title);
            if (f == null)
            {
                Create(e);
                f = e;
            }

            return f;
        }
    }
}