using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.SeedWork;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly OnlineLibraryListDbContext _dbContext;

        protected Repository(OnlineLibraryListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public Task<List<T>> FindAllAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public Task<T> FindByIdAsync(int id)
        {
            return _dbContext.Set<T>().SingleAsync(x => x.Id == id);
        }

        public void Read(T entity)
        {
            _dbContext.Attach(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public abstract Task<T> FindOrCreateAsync(T e);
    }
}