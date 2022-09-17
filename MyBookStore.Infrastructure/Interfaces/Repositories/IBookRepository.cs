using MyBookStore.Domain.Entities;

namespace MyBookStore.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<bool> ExistsAsync(string title);
        Task<IEnumerable<Book>> GetAllAsync();
        Book GetById(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Create(Book book);
        Task<bool> Update(Book book);
    }
}