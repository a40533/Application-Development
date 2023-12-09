using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.Repositories;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OnlineLibraryListDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<User>> FindAllByNameStartedWithAsync(string name)
        {
            return _dbContext.Users.Where(x => x.Username.StartsWith(name)).OrderBy(x => x.Username).ToListAsync();
        }

        public Task<User> FindByNameAsync(string name)
        {
            return _dbContext.Users.SingleOrDefaultAsync(x => x.Username == name);
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Set<User>().AsQueryable();
        }

        public User GetById(int id)
        {
            return _dbContext.Set<User>().Find(id);
        }

        public void Create(User entity)
        {
            _dbContext.Set<User>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Set<User>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public override async Task<User> FindOrCreateAsync(User e)
        {
            var f = await _dbContext.Users
                .SingleOrDefaultAsync(x => x.Username == e.Username);
            if (f == null)
            {
                Create(e);
                f = e;
            }

            return f;
        }
    }
}