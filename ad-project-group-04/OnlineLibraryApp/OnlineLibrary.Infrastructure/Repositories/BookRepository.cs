using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.Repositories;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(OnlineLibraryListDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Book>> FindAllByNameStartedWithAsync(string name)
        {
            return _dbContext.Books.Where(c => c.Title.StartsWith(name)).OrderBy(x => x.Title).ToListAsync();
        }

        public Task<Book> FindByNameAsync(string name)
        {
            return _dbContext.Books.SingleOrDefaultAsync(x => x.Title == name);
        }

        public IQueryable<Book> GetAll()
        {
            return _dbContext.Set<Book>().AsQueryable();
        }

        public Book GetById(int id)
        {
            return _dbContext.Set<Book>().Find(id);
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

        public override async Task<Book> FindOrCreateAsync(Book e)
        {
            var f = await _dbContext.Books
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