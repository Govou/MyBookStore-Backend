using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Interfaces.Repositories;
using MyBookStore.Domain.Repositories;
using MyBookStore.Infrastructure.Context;

namespace MyBookStore.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        BookStoreContext _context;
        public PublisherRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Publisher.AnyAsync(a => a.Name.Equals(name));
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publisher.AsNoTracking().ToListAsync();
        }
    }
}