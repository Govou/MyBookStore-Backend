using MyBookStore.Domain.Entities;

namespace MyBookStore.Domain.Repositories
{
    public interface IPublisherRepository
    {
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<Publisher>> GetAllAsync();
    }
}