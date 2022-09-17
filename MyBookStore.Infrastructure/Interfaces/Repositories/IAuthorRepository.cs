using MyBookStore.Domain.Entities;

namespace MyBookStore.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository 
    {
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<Author>> GetAllAsync();
    }
}