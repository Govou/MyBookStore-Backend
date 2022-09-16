using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookStore.Core.Interfaces;
using MyBookStore.Domain.Entities;

namespace MyBookStore.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<bool> ExistsAsync(string title);
        Task<IEnumerable<Book>> GetAllAsync();
        Book GetById(Guid id);
        void Delete(Guid id);
    }
}