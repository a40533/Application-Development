using OnlineLibrary.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IContactRepository ContactRepository { get; }
        IBorrowRepository BorrowRepository { get; }
        IUserRepository UserRepository { get; }
        IBookRepository BookRepository { get; }

        Task SaveAsync();
    }
}