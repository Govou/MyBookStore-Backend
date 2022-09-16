using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.Domain.Entities;
using MyBookStore.Domain.Interfaces.Repositories;
using MyBookStore.Infrastructure.Context;

namespace MyBookStore.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(SampleLibraryContext context)
            : base (context)
        {
        }

        public void Delete(Guid id)
        {
            var entity = _sampleLibraryContext.Book.FirstOrDefault(b => b.Id == id);
            _sampleLibraryContext.Book.Remove(entity);
        }

        public async Task<bool> ExistsAsync(string title)
        {
            return await _sampleLibraryContext.Book.AnyAsync(b => b.Title.Equals(title));
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _sampleLibraryContext.Book.AsNoTracking().ToListAsync();
        }

        public Book GetById(Guid id)
        {
            return _sampleLibraryContext.Book
                .AsNoTracking()
                .Include(b => b.Publisher)
                .Include(b => b.Publication)
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}