using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Domain.Models;
using OnlineLibrary.Domain.Repositories;

namespace OnlineLibrary.Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(OnlineLibraryListDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Contact>> FindAllByNameStartedWithAsync(string name)
        {
            return _dbContext.Contacts.Where(c => c.Message.StartsWith(name)).OrderBy(x => x.Message).ToListAsync();
        }

        public Task<Contact> FindByNameAsync(string name)
        {
            return _dbContext.Contacts.SingleOrDefaultAsync(x => x.Message == name);
        }

        public IQueryable<Contact> GetAll()
        {
            return _dbContext.Set<Contact>().AsQueryable();
        }

        public Contact GetById(int id)
        {
            return _dbContext.Set<Contact>().Find(id);
        }

        public void Create(Contact entity)
        {
            _dbContext.Set<Contact>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Contact entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Contact entity)
        {
            _dbContext.Set<Contact>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public override async Task<Contact> FindOrCreateAsync(Contact e)
        {
            var f = await _dbContext.Contacts
                .SingleOrDefaultAsync(x => x.Message == e.Message);
            if (f == null)
            {
                Create(e);
                f = e;
            }

            return f;
        }
    }
}