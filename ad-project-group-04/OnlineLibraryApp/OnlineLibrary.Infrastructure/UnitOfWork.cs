using System.Threading.Tasks;
using OnlineLibrary.Domain;
using OnlineLibrary.Domain.Repositories;
using OnlineLibrary.Infrastructure.Repositories;

namespace OnlineLibrary.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineLibraryListDbContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new OnlineLibraryListDbContext();

            _dbContext.Database.EnsureCreated();
        }

        public IArticleRepository ArticleRepository => new ArticleRepository(_dbContext);
        public IBookRepository BookRepository => new BookRepository(_dbContext);
        public ICategoryRepository CategoryRepository => new CategoryRepository(_dbContext);
        public IBorrowRepository BorrowRepository => new BorrowRepository(_dbContext);
        public IContactRepository ContactRepository => new ContactRepository(_dbContext);
        public IUserRepository UserRepository => new UserRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public string PrintPath()
        {
            return _dbContext.DbPath;
        }
    }
}