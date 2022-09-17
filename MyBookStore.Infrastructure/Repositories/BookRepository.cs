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
    public class BookRepository : IBookRepository
    {
        BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Book book)
        {
            _context.Book.Add(book);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var oldBook = _context.Book.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (oldBook != null)
            {
                var newBook = new Book(oldBook.Title, oldBook.AuthorId, oldBook.PublisherId, oldBook.Publication, oldBook.Id, isDeleted: true);
                try
                {
                    _context.Update(newBook);
                    var result = _context.SaveChanges();

                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
               
            }
            return false;
        }

        public async Task<bool> ExistsAsync(string title)
        {
            return await _context.Book.AnyAsync(b => b.Title.Equals(title));
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Book.AsNoTracking().Include(x => x.Author).Include(x => x.Publisher).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public Book GetById(Guid id)
        {
            return _context.Book
                .AsNoTracking()
                .Include(b => b.Publisher)
                .Include(b => b.Publication)
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }

        public async Task<bool> Update(Book book)
        {
            var oldBook = _context.Book.AsNoTracking().FirstOrDefault(x => x.Id == book.Id);
            if (oldBook != null)
            {
                var newBook = new Book(oldBook.Title, oldBook.AuthorId, oldBook.PublisherId, book.Publication, book.Id);
                _context.Book.Update(newBook);
               var result = _context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}