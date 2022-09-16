using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Interfaces.Repositories;
using MyBookStore.Infra.Data.Context;

namespace MyBookStore.Infrastructure.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(SampleLibraryContext context)
            : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _sampleLibraryContext.Author.AnyAsync(a => a.Name.Equals(name));
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _sampleLibraryContext.Author.AsNoTracking().ToListAsync();
        }

    }
}