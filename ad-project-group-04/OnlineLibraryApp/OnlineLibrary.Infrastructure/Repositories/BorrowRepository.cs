using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.Repositories;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class BorrowRepository : Repository<Borrow>, IBorrowRepository
    {
        public BorrowRepository(OnlineLibraryListDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Borrow>> FindAllByNameStartedWithAsync(string name)
        {
            return _dbContext.Borrows.Where(c => c.BorrowDate.StartsWith(name)).OrderBy(x => x.BorrowDate)
                .ToListAsync();
        }

        public Task<Borrow> FindByNameAsync(string name)
        {
            return _dbContext.Borrows.SingleOrDefaultAsync(x => x.BorrowDate == name);
        }

        public IQueryable<Borrow> GetAll()
        {
            return _dbContext.Borrows.AsQueryable();
        }

        public Borrow GetById(int id)
        {
            return _dbContext.Set<Borrow>().Find(id);
        }

        public void Create(Borrow entity)
        {
            _dbContext.Set<Borrow>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Borrow entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Borrow entity)
        {
            _dbContext.Set<Borrow>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public override async Task<Borrow> FindOrCreateAsync(Borrow e)
        {
            var f = await _dbContext.Borrows
                .SingleOrDefaultAsync(x => x.BorrowDate == e.BorrowDate);
            if (f == null)
            {
                Create(e);
                f = e;
            }

            return f;
        }
    }
}