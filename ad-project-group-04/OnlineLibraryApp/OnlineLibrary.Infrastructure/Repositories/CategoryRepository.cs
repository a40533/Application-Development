using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.Repositories;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineLibraryListDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Category>> FindAllByNameStartedWithAsync(string name)
        {
            return _dbContext.Categories.Where(c => c.Name.StartsWith(name)).OrderBy(x => x.Name).ToListAsync();
        }

        public Task<Category> FindByNameAsync(string name)
        {
            return _dbContext.Categories.SingleOrDefaultAsync(x => x.Name == name);
        }

        public IQueryable<Category> GetAll()
        {
            return _dbContext.Set<Category>().AsQueryable();
        }

        public Category GetById(int id)
        {
            return _dbContext.Set<Category>().Find(id);
        }

        public void Create(Category entity)
        {
            _dbContext.Set<Category>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Category entity)
        {
            _dbContext.Set<Category>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public override async Task<Category> FindOrCreateAsync(Category e)
        {
            var f = await _dbContext.Categories
                .SingleOrDefaultAsync(x => x.Name == e.Name);
            if (f == null)
            {
                Create(e);
                f = e;
            }

            return f;
        }
    }
}