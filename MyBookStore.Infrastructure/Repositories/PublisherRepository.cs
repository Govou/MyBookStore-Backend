using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Interfaces.Repositories;
using MyBookStore.Infrastructure.Context;

namespace SampleLibrary.Infra.Data.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(SampleLibraryContext context)
            : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _sampleLibraryContext.Publisher.AnyAsync(a => a.Name.Equals(name));
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _sampleLibraryContext.Publisher.AsNoTracking().ToListAsync();
        }
    }
}