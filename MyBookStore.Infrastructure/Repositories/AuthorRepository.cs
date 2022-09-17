using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Interfaces.Repositories;
using MyBookStore.Infrastructure.Context;
using MyBookStore.Infrastructure.Repositories;

namespace MyBookStore.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        BookStoreContext _context;
        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.Author.AnyAsync(a => a.Name.Equals(name));
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Author.AsNoTracking().ToListAsync();
        }

    }
}