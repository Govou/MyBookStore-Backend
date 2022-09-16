using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookStore.Core.Interfaces;
using MyBookStore.Domain.Entities;

namespace MyBookStore.Domain.Interfaces.Repositories
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<Publisher>> GetAllAsync();
    }
}