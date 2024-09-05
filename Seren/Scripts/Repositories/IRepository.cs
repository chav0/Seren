using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IRepository<T> where T : IIdentifiable
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task LoadItemsAsync();
}