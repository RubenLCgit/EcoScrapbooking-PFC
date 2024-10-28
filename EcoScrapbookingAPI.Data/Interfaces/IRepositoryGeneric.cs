using System.Threading.Tasks;
using System.Collections.Generic;

namespace EcoScrapbookingAPI.Data.Interfaces;

public interface IRepositoryGeneric<T> where T : class
{
  Task AddEntityAsync(T entity);
  Task<T?> GetByIdEntityAsync(int entityId);
  Task UpdateEntityAsync(T entity);
  Task DeleteEntityAsync(T entity);
  Task SaveChangesAsync();
  Task<List<T>> GetAllEntitiesAsync();
}